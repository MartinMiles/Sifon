using System;
using System.Xml;
using Sifon.Abstractions.Profiles;
using Sifon.Code.Extensions.Models;

namespace Sifon.Code.Model.Profiles
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
