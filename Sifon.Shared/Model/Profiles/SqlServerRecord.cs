using System.Xml;
using Sifon.Abstractions.Profiles;
using Sifon.Shared.Extensions.Models;

namespace Sifon.Shared.Model.Profiles
{
    internal class SqlServerRecord : ISqlServerRecord
    {
        protected XmlNode node;

        public SqlServerRecord(XmlNode _node)
        {
            node = _node;
            this.Parse(node);
        }

        #region Properties

        public string RecordName { get; set; }

        public string SqlServer { get; set; }

        public string SqlAdminUsername { get; set; }

        public string SqlAdminPassword { get; set; }

        #endregion

        public override string ToString()
        {
            return RecordName;
        }
    }
}
