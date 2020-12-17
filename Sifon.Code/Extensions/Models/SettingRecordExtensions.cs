using System.Xml;
using System.Xml.Linq;
using Sifon.Abstractions.Encryption;
using Sifon.Abstractions.Profiles;
using Sifon.Code.Model.Profiles;
using Sifon.Code.Statics;

namespace Sifon.Code.Extensions.Models
{
    public static class SettingRecordExtensions
    {
        internal static void Parse(this SettingRecord _this, XmlNode node)
        {
            _this.PortalUsername = node.ChildNodes.GetTextValue(Xml.SettingRecord.PortalUsername, Xml.Attributes.Value);
            _this.PortalPassword = node.ChildNodes.GetTextValue(Xml.SettingRecord.PortalPassword, Xml.Attributes.Value);
            _this.UseDownloadCDN = node.ChildNodes.GetBoolValue(Xml.SettingRecord.UseDownloadCDN, Xml.Attributes.Value);
            _this.SendCrashDetails = node.ChildNodes.GetBoolValue(Xml.SettingRecord.SendCrashDetails, Xml.Attributes.Value);
            _this.PluginsRepository = node.ChildNodes.GetTextValue(Xml.SettingRecord.PluginsRepository, Xml.Attributes.Value);
            _this.CustomPluginsFolder = node.ChildNodes.GetTextValue(Xml.SettingRecord.CustomPluginsFolder, Xml.Attributes.Value);
            _this.AlignVersions = node.ChildNodes.GetBoolValue(Xml.SettingRecord.AlignVersions, Xml.Attributes.Value);
        }

        internal static XElement Save(this ISettingRecord settingRecord, IEncryptor encryptor)
        {
            var root = new XElement(Xml.SettingRecord.NodeListName);

            var username = new XElement(Xml.SettingRecord.PortalUsername);
            username.SetAttributeValue(Xml.Attributes.Value, settingRecord.PortalUsername);
            root.Add(username);

            var password = new XElement(Xml.SettingRecord.PortalPassword);
            password.SetAttributeValue(Xml.Attributes.Value, encryptor.Encrypt(settingRecord.PortalPassword));
            root.Add(password);

            var useDownloadCDn = new XElement(Xml.SettingRecord.UseDownloadCDN);
            useDownloadCDn.SetAttributeValue(Xml.Attributes.Value, settingRecord.UseDownloadCDN);
            root.Add(useDownloadCDn);

            var sendCrashDetails = new XElement(Xml.SettingRecord.SendCrashDetails);
            sendCrashDetails.SetAttributeValue(Xml.Attributes.Value, settingRecord.SendCrashDetails);
            root.Add(sendCrashDetails);

            var pluginsRepository = new XElement(Xml.SettingRecord.PluginsRepository);
            pluginsRepository.SetAttributeValue(Xml.Attributes.Value, settingRecord.PluginsRepository);
            root.Add(pluginsRepository);

            var customPluginsFolder = new XElement(Xml.SettingRecord.CustomPluginsFolder);
            customPluginsFolder.SetAttributeValue(Xml.Attributes.Value, settingRecord.CustomPluginsFolder);
            root.Add(customPluginsFolder);

            var alignVersions = new XElement(Xml.SettingRecord.AlignVersions);
            alignVersions.SetAttributeValue(Xml.Attributes.Value, settingRecord.AlignVersions);
            root.Add(alignVersions);

            return root;
        }
    }
}
