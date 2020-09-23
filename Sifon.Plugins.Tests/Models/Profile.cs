using System.Collections.Generic;
using Sifon.Abstractions.Profiles;

namespace Sifon.Plugins.Tests.Models
{
    public class Profile : IProfile
    {
        public bool RemotingEnabled { get; set; }
        public string RemoteExecutionHost { get; set; }
        public string RemoteUsername { get; set; }
        public string RemotePassword { get; set; }
        public string RemoteFolder { get; set; }
        public string ProfileName { get; set; }
        public string Prefix { get; set; }
        public string AdminUsername { get; set; }
        public string AdminPassword { get; set; }
        public bool Selected { get; set; }
        public bool Empty { get; set; }
        public string Website { get; set; }
        public string SqlServer { get; set; }
        public string Solr { get; set; }
        public string Webroot { get; set; }
        public Dictionary<string, string> Parameters { get; set; }

        public ISqlServerRecord SqlServerRecord => new SqlServerRecord
        {
            RecordName = "",
            SqlServer = "",
            SqlAdminPassword = "",
            SqlAdminUsername = ""
        };

        public int ConnectionTimeout { get; } = 30;
        public int OperationTimeout { get; } = 5 * 60;
    }
}
