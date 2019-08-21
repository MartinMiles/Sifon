using System.Collections.Generic;

namespace Sifon.Abstractions.Profiles
{
    public interface IProfile
    {
        bool RemotingEnabled { get; set; }

        string RemoteExecutionHost { get; set; }

        string RemoteUsername { get; set; }

        string RemotePassword { get; set; }
        string RemoteFolder { get; set; }

        string Name { get; set; }
        string Prefix { get; set; }

        bool Selected { get; set; }

        bool Empty { get; set; }

        string Website { get; set; }

        string Solr { get; set; }

        string Webroot { get; set; }

        string SqlServer { get; set; }

        Dictionary<string, string> Parameters { get; set; }

        ISqlServerRecord SqlServerRecord { get; }

        int ConnectionTimeout { get; }

        int OperationTimeout { get; }
    }
}
