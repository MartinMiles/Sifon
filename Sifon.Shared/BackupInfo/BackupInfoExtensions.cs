using System.ComponentModel;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Sifon.Abstractions.Profiles;
using Sifon.Shared.Extensions;
using Sifon.Shared.Statics;

namespace Sifon.Shared.BackupInfo
{
    public static class BackupInfoExtensions
    {
        public static BackupInfo Parse(string xml)
        {
            if (xml.NotEmpty())
            {
                var xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(xml);
                var info = new BackupInfo();
                info.Parse(xmlDocument.DocumentElement);
                return info;
            }

            return null;
        }

        public static void Parse(this BackupInfo backupInfo, XmlElement doc)
        {
            backupInfo.Webroot = doc.ChildNodes.GetTextValue(Settings.Xml.Backup_Info.Webroot, Settings.Xml.Attributes.Value);
            backupInfo.SitecoreInstance = doc.ChildNodes.GetTextValue(Settings.Xml.Backup_Info.SitecoreInstance, Settings.Xml.Attributes.Value);
        }

        public static XElement Serialize(this BackupInfo backupInfo)
        {
            var root = new XElement(Settings.Xml.Backup_Info.NodeName);

            var webroot = new XElement(Settings.Xml.Backup_Info.Webroot);
            webroot.SetAttributeValue(Settings.Xml.Attributes.Value, backupInfo.Webroot);
            root.Add(webroot);

            var instance = new XElement(Settings.Xml.Backup_Info.SitecoreInstance);
            instance.SetAttributeValue(Settings.Xml.Attributes.Value, backupInfo.SitecoreInstance);
            root.Add(instance);

            return root;
        }

        public static async Task CreateBackupInfo(string sitecoreInstance, string webfolder, IProfile profile, ISynchronizeInvoke invoke)
        {
            var backupInfo = new BackupInfo { SitecoreInstance = sitecoreInstance, Webroot = webfolder };
            var backupInfoExtractor = new BackupInfoExtractorFactory(profile, invoke).Create();
            await backupInfoExtractor.SaveToFile(backupInfo);
        }
    }
}
