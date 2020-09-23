using System.Collections.Generic;
using System.Xml;
using Sifon.Abstractions.Profiles;
using Sifon.Shared.Extensions.Models;

namespace Sifon.Shared.Model.Profiles
{
    internal class Profile : IProfile
    {
        protected XmlNode node;

        #region Constructors

        public Profile()
        {
        }

        public Profile(XmlNode _node)
        {
            node = _node;
            this.Parse(_node);
        }

        #endregion

        #region Properties

        public bool RemotingEnabled { get; set; }

        public string RemoteExecutionHost { get; set; }

        public string RemoteUsername { get; set; }

        public string RemotePassword { get; set; }
        public string RemoteFolder { get; set; }

        public string ProfileName { get; set; }

        public bool Selected { get; set; }

        public bool Empty { get; set; }

        public string Website { get; set; }

        public string Solr { get; set; }

        public string Webroot { get; set; }

        public string SqlServer { get; set; }

        public string Prefix { get; set; }

        public string AdminUsername { get; set; }

        public string AdminPassword { get; set; }

        public Dictionary<string, string> Parameters { get; set; }

        #endregion

        public ISqlServerRecord SqlServerRecord => this.GetSqlProfile();
        public int ConnectionTimeout { get; } = 30;

        public int OperationTimeout { get; } = 60 * 5;

        public override string ToString()
        {
            return Prefix;
        }
    }
}
