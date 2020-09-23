using System.Collections.Generic;

namespace Sifon.Abstractions.Profiles
{
    public interface IProfile : IProfileUserControl
    {
        bool RemotingEnabled { get; set; }

        string RemoteExecutionHost { get; set; }

        string RemoteUsername { get; set; }

        string RemotePassword { get; set; }
        string RemoteFolder { get; set; }

        string ProfileName { get; set; }

        string Prefix { get; set; }
        
        string AdminUsername { get; set; }
        
        string AdminPassword { get; set; }

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
