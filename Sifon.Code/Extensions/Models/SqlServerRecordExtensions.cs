using System.Xml;
using System.Xml.Linq;
using Sifon.Abstractions.Profiles;
using Sifon.Code.Model.Profiles;
using Sifon.Code.Statics;

namespace Sifon.Code.Extensions.Models
{
    public static class SqlServerRecordExtensions
    {
        internal static void Parse(this SqlServerRecord _this , XmlNode node)
        {
            _this.RecordName = node.ChildNodes.GetTextValue(Xml.SqlServerRecord.RecordName, Xml.Attributes.Value);
            _this.SqlServer = node.ChildNodes.GetTextValue(Xml.SqlServerRecord.SqlServer, Xml.Attributes.Value);
            _this.SqlAdminUsername = node.ChildNodes.GetTextValue(Xml.SqlServerRecord.SqlAdminUsername, Xml.Attributes.Value);
            _this.SqlAdminPassword = node.ChildNodes.GetTextValue(Xml.SqlServerRecord.SqlAdminPassword, Xml.Attributes.Value);
        }

        public static XElement Save(this ISqlServerRecord _this)
        {
            var root = new XElement(Xml.SqlServerRecord.NodeName);

            var name = new XElement(Xml.SqlServerRecord.RecordName);
            name.SetAttributeValue(Xml.Attributes.Value, _this.RecordName);
            root.Add(name);

            var sqlServer = new XElement(Xml.SqlServerRecord.SqlServer);
            sqlServer.SetAttributeValue(Xml.Attributes.Value, _this.SqlServer);
            root.Add(sqlServer);

            var sqlUser = new XElement(Xml.SqlServerRecord.SqlAdminUsername);
            sqlUser.SetAttributeValue(Xml.Attributes.Value, _this.SqlAdminUsername);
            root.Add(sqlUser);

            var sqlPassword = new XElement(Xml.SqlServerRecord.SqlAdminPassword);
            sqlPassword.SetAttributeValue(Xml.Attributes.Value, _this.SqlAdminPassword);
            root.Add(sqlPassword);

            return root;
        }
    }
}