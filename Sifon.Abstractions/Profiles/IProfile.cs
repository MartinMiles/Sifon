using System.Collections.Generic;

namespace Sifon.Abstractions.Profiles
{
    public interface IProfile : IProfileUserControl, IRemoteSettings
    {
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
