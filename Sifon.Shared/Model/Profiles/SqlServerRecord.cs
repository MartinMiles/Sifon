using System;
using System.Xml;
using Sifon.Abstractions.Profiles;
using Sifon.Shared.Extensions.Models;

namespace Sifon.Shared.Model.Profiles
{
    internal class SqlServerRecord : ISqlServerRecord
    {
        protected XmlNode node;

        public SqlServerRecord()
        {
        }

        public SqlServerRecord(XmlNode _node)
        {
            node = _node;
            this.Parse(node);
        }

        #region Properties

        public string RecordName { get; set; } = String.Empty;

        public string SqlServer { get; set; } = String.Empty;

        public string SqlAdminUsername { get; set; } = String.Empty;

        public string SqlAdminPassword { get; set; } = String.Empty;

        #endregion

        public override string ToString()
        {
            return RecordName;
        }
    }
}
