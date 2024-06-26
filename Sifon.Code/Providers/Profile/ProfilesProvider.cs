﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Xml;
using System.Xml.Linq;
using Sifon.Abstractions.Model.BackupRestore;
using Sifon.Abstractions.Profiles;
using Sifon.Abstractions.Providers;
using Sifon.Code.Statics;
using Sifon.Code.Extensions;
using Sifon.Code.Extensions.Models;

namespace Sifon.Code.Providers.Profile
{
    internal class ProfilesProvider : BaseEncryptedProvider, IProfilesProvider
    {
        private IEnumerable<IProfile> _profiles;

        internal ProfilesProvider()
        {
            Read();
        }

        #region CRUD

        public void Append(IProfile p)
        {
            _profiles = _profiles.Append(p);
        }

        public void Add(IProfileUserControl p)
        {
            var profile = new Model.Profiles.Profile
            {
                IsXM = p.IsXM,
                ProfileName = p.ProfileName, 
                Prefix = p.Prefix, 
                AdminUsername = p.AdminUsername,
                AdminPassword = p.AdminPassword
            };


            _profiles = _profiles.Append(profile);
        }

        public IEnumerable<IProfile> Read()
        {
            var items = new List<IProfile>();

            if (File.Exists(Folders.SettingsFolder.ProfilesPath))
            {
                var doc = new XmlDocument();
                doc.Load(Folders.SettingsFolder.ProfilesPath);

                if(doc.DocumentElement != null)
                { 
                    foreach (XmlNode node in doc.DocumentElement.ChildNodes)
                    {
                        items.Add(new Model.Profiles.Profile(node, Encryptor));
                    }
                }
            }

            _profiles = items;
            return _profiles;
        }

        public void Save()
        {
            var doc = new XDocument();
            var root = new XElement(Xml.Profile.NodeListName);
            doc.Add(root);

            foreach (IProfile profile in _profiles)
            {
                root.Add(profile.Save(Encryptor));
            }

            doc.Save(Folders.SettingsFolder.ProfilesPath);
        }

        public void DeleteSelected()
        {
            var list = _profiles.ToList();
            var removed = list.Remove(_profiles.First(p => p.ProfileName == SelectedProfile.ProfileName));
            if (list.Any())
            {
                list.First().Selected = true;
            }
            _profiles = list;
        }

        #endregion

        public IProfile ProfileByName(string profileName)
        {
            return _profiles.FirstOrDefault(p => p.ProfileName.Compare(profileName));
        }

        public void UpdateSelected(IProfile profile)
        {
            var selected = _profiles.FirstOrDefault(p => p.Selected);
            if (selected != null)
            {
                selected.IsXM = profile.IsXM;
                selected.RemotingEnabled = profile.RemotingEnabled;
                selected.RemoteHost = profile.RemoteHost;
                selected.RemoteUsername = profile.RemoteUsername;
                selected.RemotePassword = profile.RemotePassword;
                selected.ProfileName = profile.ProfileName;
                selected.Prefix = profile.Prefix;
                selected.Webroot = profile.Webroot;
                selected.Website = profile.Website;
                selected.XConnectSiteName = profile.XConnectSiteName;
                selected.XConnectSiteRoot = profile.XConnectSiteRoot;
                selected.CDSiteName = profile.CDSiteName;
                selected.CDSiteRoot = profile.CDSiteRoot;
                selected.Solr = profile.Solr;
                selected.SqlServer = profile.SqlServer;
                selected.Parameters = profile.Parameters;
            }
        }

        public IProfile SelectedProfile => _profiles.FirstOrDefault(p => p.Selected);

        public ISqlServerRecord SelectedProfileSql => SelectedProfile.SqlServerRecord;

        public bool Any => _profiles.Any();
        public int Count => _profiles.Count();

        private IProfile GetByName(string profileName)
        {
            return _profiles.FirstOrDefault(p => String.Equals(p.ProfileName, profileName, StringComparison.OrdinalIgnoreCase));
        }

        public void SelectProfile(string selectedProfileName)
        {
            SelectProfile(GetByName(selectedProfileName));
            Save();
        }

        public void SelectProfile(IProfile selectedProfile)
        {
            foreach (var profile in _profiles)
            {
                profile.Selected = false;
            }

            selectedProfile.Selected = true;
        }

        public void AddScriptProfileParameters(Dictionary<string, dynamic> parameters, bool executeLocalEnforced = false)
        {
            parameters.Add(Settings.Parameters.Name, SelectedProfile.ProfileName);
            parameters.Add(Settings.Parameters.Prefix, SelectedProfile.Prefix);
            parameters.Add(Settings.Parameters.AdminUsername, SelectedProfile.AdminUsername);
            parameters.Add(Settings.Parameters.AdminPassword, SelectedProfile.AdminPassword);
            parameters.Add(Settings.Parameters.Website, SelectedProfile.Website);
            parameters.Add(Settings.Parameters.Webroot, SelectedProfile.Webroot);
            parameters.Add(Settings.Parameters.Solr, SelectedProfile.Solr);
            //TODO: Add new parameters to be exmplicitly passed, rather than through a profile
            parameters.Add(Settings.Parameters.IsXM, !executeLocalEnforced && SelectedProfile.RemotingEnabled);
            parameters.Add(Settings.Parameters.IsRemote, !executeLocalEnforced && SelectedProfile.RemotingEnabled);
            parameters.Add("Profile", SelectedProfile);

            if (SelectedProfileSql != null)
            {
                var credential = new PSCredential(SelectedProfileSql.SqlAdminUsername, SelectedProfileSql.SqlAdminPassword.ToSecureString());
                parameters.Add(Settings.Parameters.SqlCredentials, credential);
                parameters.Add(Settings.Parameters.ServerInstance, SelectedProfileSql.SqlServer);
            }

            foreach (var parameter in SelectedProfile.Parameters)
            {
                parameters.Add(parameter.Key, parameter.Value);
            }
        }
        
        //TODO: Add support for XM topology for Backup and restore
        public void AddBackupRemoveParameters(Dictionary<string, dynamic> parameters, IBackupRemoverViewModel model)
        {
            parameters.Add(Settings.Parameters.TargetFolder, model.DestinationFolder);
            parameters.Add(Settings.Parameters.XConnectFolder, model.XConnectFolder);
            parameters.Add(Settings.Parameters.IdentityServerFolder, model.IdentityFolder);
            parameters.Add(Settings.Parameters.HorizonFolder, model.HorizonFolder);
            parameters.Add(Settings.Parameters.PublishingServiceFolder, model.PublishingFolder);
            parameters.Add(Settings.Parameters.Databases, model.Databases);
        }

        public void AddRestoreParameters(Dictionary<string, dynamic> parameters, IRestoreZips model)
        {
            // pass zip archive as $Website into restore script (a minor hack)
            parameters[Settings.Parameters.Website] = model.WebsiteZip;

            parameters.Add(Settings.Parameters.XConnect, model.XConnectZip);
            parameters.Add(Settings.Parameters.IdentityServer, model.IdentityZip);
            parameters.Add(Settings.Parameters.Horizon, model.HorizonZip);
            parameters.Add(Settings.Parameters.PublishingService, model.PublishingZip);
        }

        public void AddCommerceScriptParameters(Dictionary<string, dynamic> parameters, IEnumerable<KeyValuePair<string, string>> commerceSites)
        {
            if (commerceSites != null)
            {
                foreach (var commerceSite in commerceSites)
                {
                    var param = Path.GetFileName(commerceSite.Value);

                    parameters.Add(param, commerceSite.Key);
                    parameters.Add(param + "Folder", commerceSite.Value);
                }
            }
        }

        public void AssignSqlServer(string sqlServerRecordName)
        {
            var profile = SelectedProfile;
            profile.SqlServer = sqlServerRecordName;
        }

        public IProfile CreateProfile(string proposedName = null)
        {
            var profile = new Model.Profiles.Profile();

            if (!string.IsNullOrWhiteSpace(proposedName))
            {
                profile.ProfileName = ProposeProfileName(proposedName);
            }

            return profile;
        }

        private string ProposeProfileName(string prefix)
        {
            int count = 1;
            string tempName = prefix;
            var _p = GetByName(tempName);

            while (_p != null)
            {
                tempName = $"{_p.ProfileName} ({count++})";
                _p = GetByName(tempName);
            }

            return tempName;
        }

        public IProfile CreateProfile(IRemoteSettings remoteSettings)
        {
            var profile = CreateProfile();

            profile.RemotingEnabled = remoteSettings.RemotingEnabled;
            profile.RemoteHost = remoteSettings.RemoteHost;
            profile.RemoteUsername = remoteSettings.RemoteUsername;
            profile.RemotePassword = remoteSettings.RemotePassword;
            profile.RemoteFolder = remoteSettings.RemoteFolder;

            return profile;
        }
        public IProfile CreateLocal()
        {
            var profile = CreateProfile();

            profile.RemotingEnabled = false;
            profile.RemoteHost = String.Empty;
            profile.RemoteUsername = String.Empty;
            profile.RemotePassword = String.Empty;
            profile.RemoteFolder = String.Empty;

            return profile;
        }

        public string FindPrefixByName(string siteName)
        {
            var possiblePrefix = _profiles.FirstOrDefault(p => p.Website.Equals(siteName, StringComparison.InvariantCultureIgnoreCase))?.Prefix;

            if (possiblePrefix == null && siteName.Contains("."))
            {
                possiblePrefix = siteName.Substring(0, siteName.IndexOf("."));
            }

            return possiblePrefix;
        }
    }
}
