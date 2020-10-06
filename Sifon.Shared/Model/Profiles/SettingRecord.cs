using System;
using System.Xml;
using Sifon.Abstractions.Profiles;
using Sifon.Shared.Extensions.Models;

namespace Sifon.Shared.Model.Profiles
{
    internal class SettingRecord : ISettingRecord
    {
        protected XmlNode node;

        public string PortalUsername { get; set; } = String.Empty;
        public string PortalPassword { get; set; } = String.Empty;

        #region Constructors

        public SettingRecord()
        {
        }
        public SettingRecord(XmlNode _node)
        {
            node = _node;
            this.Parse(node);
        }

        #endregion
    }
}
