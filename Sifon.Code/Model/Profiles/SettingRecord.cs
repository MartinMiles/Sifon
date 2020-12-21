using System;
using System.Xml;
using Sifon.Abstractions.Profiles;
using Sifon.Code.Extensions.Models;
using Sifon.Code.Statics;

namespace Sifon.Code.Model.Profiles
{
    internal class SettingRecord : ISettingRecord
    {
        protected XmlNode node;

        public string PortalUsername { get; set; } = String.Empty;
        public string PortalPassword { get; set; } = String.Empty;
        public bool SendCrashDetails { get; set; }
        public bool UseDownloadCDN { get; set; }
        public string PluginsRepository { get; set; } = String.Empty;
        public string CustomPluginsFolder { get; set; } = String.Empty;
        public bool AlignVersions { get; set; }
        
        #region Constructors

        public SettingRecord()
        {
            SendCrashDetails = true;
            UseDownloadCDN = true;
            PluginsRepository = Settings.PluginRepository;
            AlignVersions = true;
        }
        public SettingRecord(XmlNode _node)
        {
            node = _node;
            this.Parse(node);
        }

        #endregion
    }
}
