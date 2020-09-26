using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using Sifon.Abstractions.Model.BackupRestore;
using Sifon.Abstractions.Profiles;
using Sifon.Shared.Extensions;
using Sifon.Shared.Extensions.Models;
using Sifon.Shared.Statics;

namespace Sifon.Shared.Providers.Profile
{
    public class ProfilesProvider
    {
        private IEnumerable<Model.Profiles.Profile> _profiles;

        public ProfilesProvider()
        {
            Read();
        }

        #region CRUD

        public void Add(IProfileUserControl p)
        {
            var profile = new Model.Profiles.Profile
            {
                ProfileName = p.ProfileName, Prefix = p.Prefix, AdminUsername = p.AdminUsername,
                AdminPassword = p.AdminPassword
            };

            _profiles = _profiles.Append(profile);
        }

        public IEnumerable<IProfile> Read()
        {
            var items = new List<Model.Profiles.Profile>();

            if (File.Exists(Settings.ProfilesFolder.ProfilesPath))
            {
                var doc = new XmlDocument();
                doc.Load(Settings.ProfilesFolder.ProfilesPath);

                foreach (XmlNode node in doc.DocumentElement.ChildNodes)
                {
                    items.Add(new Model.Profiles.Profile(node));
                }
            }

            _profiles = items;
            return _profiles;
        }

        public void Save()
        {
            var doc = new XDocument();
            var root = new XElement(Settings.Xml.Profile.NodeListName);
            doc.Add(root);

            foreach (Model.Profiles.Profile profile in _profiles)
            {
                root.Add(profile.Save());
            }

            doc.Save(Settings.ProfilesFolder.ProfilesPath);
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
                selected.RemotingEnabled = profile.RemotingEnabled;
                selected.RemoteExecutionHost = profile.RemoteExecutionHost;
                selected.RemoteUsername = profile.RemoteUsername;
                selected.RemotePassword = profile.RemotePassword;
                selected.ProfileName = profile.ProfileName;
                selected.Prefix = profile.Prefix;
                selected.Webroot = profile.Webroot;
                selected.Website = profile.Website;
                selected.Solr = profile.Solr;
                selected.SqlServer = profile.SqlServer;
                selected.Parameters = profile.Parameters;
            }
        }

        public IProfile SelectedProfile => _profiles.FirstOrDefault(p => p.Selected);

        public ISqlServerRecord SelectedProfileSql => SelectedProfile.SqlServerRecord;

        public bool Any => _profiles.Any();

        private Model.Profiles.Profile GetByName(string profileName)
        {
            return _profiles.FirstOrDefault(p => p.ProfileName == profileName);
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

        public void AddScriptProfileParameters(Dictionary<string, dynamic> parameters)
        {
            parameters.Add(Settings.Parameters.Name, SelectedProfile.ProfileName);
            parameters.Add(Settings.Parameters.Prefix, SelectedProfile.Prefix);
            parameters.Add(Settings.Parameters.AdminUsername, SelectedProfile.AdminUsername);
            parameters.Add(Settings.Parameters.AdminPassword, SelectedProfile.AdminPassword);
            parameters.Add(Settings.Parameters.Website, SelectedProfile.Website);
            parameters.Add(Settings.Parameters.Webroot, SelectedProfile.Webroot);
            parameters.Add(Settings.Parameters.Solr, SelectedProfile.Solr);

            parameters.Add(Settings.Parameters.ServerInstance, SelectedProfileSql.SqlServer);
            parameters.Add(Settings.Parameters.Username, SelectedProfileSql.SqlAdminUsername);
            parameters.Add(Settings.Parameters.Password, SelectedProfileSql.SqlAdminPassword);

            foreach (var parameter in SelectedProfile.Parameters)
            {
                parameters.Add(parameter.Key, parameter.Value);
            }
        }
        
        public void AddScriptModelParameters(Dictionary<string, dynamic> parameters, IBackupRestoreModel model)
        {
            parameters.Add(Settings.Parameters.XConnect, model.XConnect);
            parameters.Add(Settings.Parameters.IdentityServer, model.IdentityServer);
            parameters.Add(Settings.Parameters.XConnectFolder, model.XConnectFolder);
            parameters.Add(Settings.Parameters.IdentityServerFolder, model.IdentityServerFolder);
            parameters.Add(Settings.Parameters.Horizon, model.Horizon);
            parameters.Add(Settings.Parameters.HorizonFolder, model.HorizonFolder);
            parameters.Add(Settings.Parameters.PublishingService, model.PublishingService);
            parameters.Add(Settings.Parameters.PublishingServiceFolder, model.PublishingServiceFolder);
            parameters.Add(Settings.Parameters.TargetFolder, model.DestinationFolder);
            parameters.Add(Settings.Parameters.Databases, model.SelectedDatabases);
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

        public IProfile CreateProfile()
        {
            return new Model.Profiles.Profile();
        }
        public IProfile CreateProfile(IRemoteSettings remoteSettings)
        {
            var profile = CreateProfile();

            profile.RemotingEnabled = remoteSettings.RemotingEnabled;
            profile.RemoteExecutionHost = remoteSettings.RemoteHostname;
            profile.RemoteUsername = remoteSettings.RemoteUsername;
            profile.RemotePassword = remoteSettings.RemotePassword;
            profile.RemoteFolder = remoteSettings.RemoteFolder;

            return profile;
        }
        public IProfile CreateLocal()
        {
            var profile = CreateProfile();

            profile.RemotingEnabled = false;
            profile.RemoteExecutionHost = String.Empty;
            profile.RemoteUsername = String.Empty;
            profile.RemotePassword = String.Empty;
            profile.RemoteFolder = String.Empty;

            return profile;
        }
    }
}
