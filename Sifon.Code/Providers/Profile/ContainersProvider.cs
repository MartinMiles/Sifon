using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using Sifon.Abstractions.Profiles;
using Sifon.Abstractions.Providers;
using Sifon.Code.Model.Profiles;
using Sifon.Code.Statics;
using Sifon.Code.Extensions.Models;

namespace Sifon.Code.Providers.Profile
{
    internal class ContainersProvider : IContainersProvider
    {
        private IEnumerable<ContainerProfile> _profiles;

        internal ContainersProvider()
        {
            VerifyFirstRun();
            Read();
        }

        private void VerifyFirstRun()
        {
            if (!File.Exists(Settings.SettingsFolder.ContainersPath))
            {
                _profiles = new List<ContainerProfile>();
                _profiles = _profiles.Append(DefaultContainers.Sitecore10XP);
                _profiles = _profiles.Append(DefaultContainers.LighthouseDemo);

                SelectProfile(_profiles.First());
                Save();
            }
        }

        #region CRUD

        public void Add(IContainerProfile p)
        {
            var profile = new ContainerProfile
            {
                ContainerProfileName = p.ContainerProfileName,
                Repository = p.Repository,
                Folder = p.Folder,
                SitecoreAdminPassword = p.SitecoreAdminPassword,
                SaPassword = p.SaPassword,
                InitializeScript = p.InitializeScript,
                Notes = p.Notes
            };

            _profiles = _profiles.Append(profile);
        }

        public IEnumerable<IContainerProfile> Read()
        {
            var items = new List<ContainerProfile>();

            if (File.Exists(Settings.SettingsFolder.ContainersPath))
            {
                var doc = new XmlDocument();
                doc.Load(Settings.SettingsFolder.ContainersPath);

                foreach (XmlNode node in doc.DocumentElement.ChildNodes)
                {
                    items.Add(new ContainerProfile(node));
                }
            }

            _profiles = items;
            return _profiles;
        }

        public void Save()
        {
            var doc = new XDocument();
            var root = new XElement(Xml.ContainerProfile.NodeListName);
            doc.Add(root);

            foreach (ContainerProfile profile in _profiles)
            {
                root.Add(profile.Save());
            }

            doc.Save(Settings.SettingsFolder.ContainersPath);
        }

        public void DeleteSelected()
        {
            var list = _profiles.ToList();
            var removed = list.Remove(_profiles.First(p => p.ContainerProfileName == SelectedProfile.ContainerProfileName));
            if (list.Any())
            {
                list.First().Selected = true;
            }
            _profiles = list;
        }

        #endregion

        public void SelectProfile(IContainerProfile selectedProfile)
        {
            foreach (var profile in _profiles)
            {
                profile.Selected = false;
            }

            selectedProfile.Selected = true;
        }

        public void SelectProfile(string selectedProfileName)
        {
            SelectProfile(GetByName(selectedProfileName));
            Save();
        }

        private ContainerProfile GetByName(string profileName)
        {
            return _profiles.FirstOrDefault(p => p.ContainerProfileName == profileName);
        }

        public IEnumerable<string> Profiles => Read().Select(p => p.ContainerProfileName);
        
        public IContainerProfile SelectedProfile => _profiles.FirstOrDefault(p => p.Selected);


        public void AddContainersParameters(Dictionary<string, object> parameters)
        {
            Read();

            if (SelectedProfile != null)
            {
                parameters.Add(Settings.Parameters.ContainerProfileName, SelectedProfile.ContainerProfileName);
                parameters.Add(Settings.Parameters.Repository, SelectedProfile.Repository);
                parameters.Add(Settings.Parameters.Folder, SelectedProfile.Folder);
                parameters.Add(Settings.Parameters.SitecoreAdminPassword, SelectedProfile.SitecoreAdminPassword);
                parameters.Add(Settings.ContainerParameters.SaPassword, SelectedProfile.SaPassword);
                parameters.Add(Settings.ContainerParameters.InitParams, SelectedProfile.InitializeScript);
            }
        }
    }
}
