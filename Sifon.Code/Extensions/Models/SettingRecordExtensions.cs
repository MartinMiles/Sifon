using System.Xml;
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
        }
    }
}
