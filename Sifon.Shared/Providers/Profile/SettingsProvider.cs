using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using Sifon.Abstractions.Profiles;
using Sifon.Shared.Encryption;
using Sifon.Shared.Extensions;
using Sifon.Shared.Model.Profiles;
using Sifon.Shared.Statics;

namespace Sifon.Shared.Providers.Profile
{
    public class SettingsProvider
    {
        private ISettingRecord _entity;
        private readonly Encryptor _encryptor;

        public SettingsProvider()
        {
            _encryptor = new Encryptor();
            _entity = Read();
        }

        #region CRUD

        public ISettingRecord Read()
        {
            _entity = new SettingRecord();

            if (File.Exists(Settings.SettingsFolder.SettingsPath))
            {
                var doc = new XmlDocument();
                doc.Load(Settings.SettingsFolder.SettingsPath);

                _entity = new SettingRecord(doc.DocumentElement);

                if (!string.IsNullOrWhiteSpace(_entity.PortalPassword))
                {
                    _entity.PortalPassword = _encryptor.Decrypt(_entity.PortalPassword);
                }
            }

            return _entity;
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
            password.SetAttributeValue(Settings.Xml.Attributes.Value, _encryptor.Encrypt(settingRecord.PortalPassword));
            root.Add(password);

            doc.Save(Settings.SettingsFolder.SettingsPath);
        }

        #endregion

        public void AddScriptSettingsParameters(Dictionary<string, object> parameters)
        {
            Read();

            if (_entity.PortalUsername.NotEmpty() && _entity.PortalPassword.NotEmpty())
            {
                TestScriptSettingsParameters(parameters, _entity.PortalUsername, _entity.PortalPassword);
            }
        }

        public void TestScriptSettingsParameters(Dictionary<string, object> parameters, string username, string password)
        {
            var credential = new System.Management.Automation.PSCredential(username, password.ToSecureString());
            parameters.Add(Settings.Parameters.PortalCredentials, credential);
        }
    }
}
