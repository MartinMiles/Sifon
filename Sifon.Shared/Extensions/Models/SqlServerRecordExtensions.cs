using System.Xml;
using System.Xml.Linq;
using Sifon.Abstractions.Profiles;
using Sifon.Shared.Model.Profiles;
using Sifon.Shared.Statics;

namespace Sifon.Shared.Extensions.Models
{
    public static class SqlServerRecordExtensions
    {
        internal static void Parse(this SqlServerRecord _this , XmlNode node)
        {
            _this.RecordName = node.ChildNodes.GetTextValue(Settings.Xml.SqlServerRecord.RecordName, Settings.Xml.Attributes.Value);
            _this.SqlServer = node.ChildNodes.GetTextValue(Settings.Xml.SqlServerRecord.SqlServer, Settings.Xml.Attributes.Value);
            _this.SqlAdminUsername = node.ChildNodes.GetTextValue(Settings.Xml.SqlServerRecord.SqlAdminUsername, Settings.Xml.Attributes.Value);
            _this.SqlAdminPassword = node.ChildNodes.GetTextValue(Settings.Xml.SqlServerRecord.SqlAdminPassword, Settings.Xml.Attributes.Value);
        }

        internal static void Parse(this SettingRecord _this, XmlNode node)
        {
            _this.PortalUsername = node.ChildNodes.GetTextValue(Settings.Xml.SettingRecord.PortalUsername, Settings.Xml.Attributes.Value);
            // TODO: Decrypt password
            _this.PortalPassword = node.ChildNodes.GetTextValue(Settings.Xml.SettingRecord.PortalPassword, Settings.Xml.Attributes.Value);
        }

        public static XElement Save(this ISqlServerRecord _this)
        {
            var root = new XElement(Settings.Xml.SqlServerRecord.NodeName);

            var name = new XElement(Settings.Xml.SqlServerRecord.RecordName);
            name.SetAttributeValue(Settings.Xml.Attributes.Value, _this.RecordName);
            root.Add(name);

            var sqlServer = new XElement(Settings.Xml.SqlServerRecord.SqlServer);
            sqlServer.SetAttributeValue(Settings.Xml.Attributes.Value, _this.SqlServer);
            root.Add(sqlServer);

            var sqlUser = new XElement(Settings.Xml.SqlServerRecord.SqlAdminUsername);
            sqlUser.SetAttributeValue(Settings.Xml.Attributes.Value, _this.SqlAdminUsername);
            root.Add(sqlUser);

            var sqlPassword = new XElement(Settings.Xml.SqlServerRecord.SqlAdminPassword);
            sqlPassword.SetAttributeValue(Settings.Xml.Attributes.Value, _this.SqlAdminPassword);
            root.Add(sqlPassword);

            return root;
        }
    }
}