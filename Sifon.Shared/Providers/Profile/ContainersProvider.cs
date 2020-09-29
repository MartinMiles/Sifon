using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using Sifon.Abstractions.Profiles;
using Sifon.Shared.Extensions.Models;
using Sifon.Shared.Model.Profiles;
using Sifon.Shared.Statics;

namespace Sifon.Shared.Providers.Profile
{
    public class ContainersProvider
    {
        private IEnumerable<ContainerProfile> _profiles;

        public ContainersProvider()
        {
            Read();
        }

        #region CRUD

        public void Add(IContainerProfile p)
        {
            var profile = new ContainerProfile
            {
                ProfileName = p.ProfileName,
                Repository = p.Repository,
                Folder = p.Folder,
                AdminPassword = p.AdminPassword,
                SaPassword = p.SaPassword
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
            var root = new XElement(Settings.Xml.ContainerProfile.NodeListName);
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
            var removed = list.Remove(_profiles.First(p => p.ProfileName == SelectedProfile.ProfileName));
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
            return _profiles.FirstOrDefault(p => p.ProfileName == profileName);
        }

        public IEnumerable<string> Profiles => Read().Select(p => p.ProfileName);
        
        public IContainerProfile SelectedProfile => _profiles.FirstOrDefault(p => p.Selected);


        public void AddContainersParameters(Dictionary<string, object> parameters)
        {
            Read();

            if (SelectedProfile != null)
            {
                parameters.Add(Settings.Parameters.ProfileName, SelectedProfile.ProfileName);
                parameters.Add(Settings.Parameters.Repository, SelectedProfile.Repository);
                parameters.Add(Settings.Parameters.Folder, SelectedProfile.Folder);
                    
                // Commented as an item with this key already coming from a profile, it's ok since they don't intersect
                //parameters.Add(Settings.Parameters.AdminPassword, SelectedProfile.AdminPassword);
                parameters.Add(Settings.Parameters.SaPassword, SelectedProfile.SaPassword);
            }
        }
    }
}
