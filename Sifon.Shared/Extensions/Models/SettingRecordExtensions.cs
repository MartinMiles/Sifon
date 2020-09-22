using System.Xml;
using Sifon.Shared.Model.Profiles;
using Sifon.Shared.Statics;

namespace Sifon.Shared.Extensions.Models
{
    public static class SettingRecordExtensions
    {
        internal static void Parse(this SettingRecord _this, XmlNode node)
        {
            _this.PortalUsername = node.ChildNodes.GetTextValue(Settings.Xml.SettingRecord.PortalUsername, Settings.Xml.Attributes.Value);
            _this.PortalPassword = node.ChildNodes.GetTextValue(Settings.Xml.SettingRecord.PortalPassword, Settings.Xml.Attributes.Value);
        }
    }
}
