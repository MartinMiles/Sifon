using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using Sifon.Abstractions.Profiles;
using Sifon.Code.Model.Profiles;
using Sifon.Code.Statics;
using Sifon.Code.Extensions;
using Sifon.Code.Extensions.Models;

namespace Sifon.Code.Providers.Profile
{
    //TODO: Add interface and use it instead
    public class SettingsProvider : BaseEncryptedProvider
    {
        private ISettingRecord _entity;

        public SettingsProvider()
        {
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
                    _entity.PortalPassword = Encryptor.Decrypt(_entity.PortalPassword);
                }
            }

            return _entity;
        }

        public void SaveCredentials(IPortalCredentials portalCredentials)
        {
            _entity.PortalUsername = portalCredentials.PortalUsername;
            _entity.PortalPassword = portalCredentials.PortalPassword;

            SaveSettings();
        }

        public void SaveCrashDetails(ICrashDetails crashDetails)
        {
            _entity.SendCrashDetails = crashDetails.SendCrashDetails;

            SaveSettings();
        }

        private void SaveSettings()
        {
            var doc = new XDocument();
            doc.Add(_entity.Save(Encryptor));
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
