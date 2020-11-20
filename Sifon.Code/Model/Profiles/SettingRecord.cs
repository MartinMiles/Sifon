using System;
using System.Xml;
using Sifon.Abstractions.Profiles;
using Sifon.Code.Extensions.Models;
using Sifon.Code.Statics;

namespace Sifon.Code.Model.Profiles
{
    internal class SettingRecord : ISettingRecord, ICrashDetails
    {
        protected XmlNode node;

        public string PortalUsername { get; set; } = String.Empty;
        public string PortalPassword { get; set; } = String.Empty;
        public bool SendCrashDetails { get; set; }
        public string PluginsRepository { get; set; } = String.Empty;

        #region Constructors

        public SettingRecord()
        {
            SendCrashDetails = true;
            PluginsRepository = Settings.PluginRepository;
        }
        public SettingRecord(XmlNode _node)
        {
            node = _node;
            this.Parse(node);
        }

        #endregion
    }
}
