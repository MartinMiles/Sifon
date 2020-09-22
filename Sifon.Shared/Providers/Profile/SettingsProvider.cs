using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Sifon.Abstractions.Profiles;
using Sifon.Shared.Model.Profiles;
using Sifon.Shared.Statics;

namespace Sifon.Shared.Providers.Profile
{
    public class SettingsProvider
    {
        private ISettingRecord _entities;

        public SettingsProvider()
        {
            _entities = Read();
        }

        #region CRUD

        public void Add(ISqlServerRecord record)
        {
            //_entities = _entities.Append(record);
        }

        public ISettingRecord Read()
        {
            if (!File.Exists(Settings.ProfilesFolder.SettingsPath))
            {
                throw new FileNotFoundException($"Settings file missing at: {Settings.ProfilesFolder.SettingsPath}");
            }

            var doc = new XmlDocument();
            doc.Load(Settings.ProfilesFolder.SettingsPath);

            _entities = new SettingRecord(doc.DocumentElement);
            return _entities;
        }

        public void Save(ISettingRecord settingRecord)
        {
            var doc = new XDocument();
            var root = new XElement(Settings.Xml.SettingRecord.NodeListName);
            doc.Add(root);

            var username = new XElement(Settings.Xml.SettingRecord.PortalUsername);
            username.SetAttributeValue(Settings.Xml.Attributes.Value, settingRecord.PortalUsername);
            root.Add(username);

            var password = new XElement(Settings.Xml.SettingRecord.PortalPassword);
            password.SetAttributeValue(Settings.Xml.Attributes.Value, settingRecord.PortalPassword);
            root.Add(password);

            doc.Save(Settings.ProfilesFolder.SettingsPath);
        }

        #endregion
    }
}
