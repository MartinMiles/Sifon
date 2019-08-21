using Sifon.Abstractions.Profiles;

namespace Sifon.Plugins.Tests.Models
{
    public class SqlServerRecord : ISqlServerRecord
    {
        public string RecordName { get; set; }
        public string SqlServer { get; set; }
        public string SqlAdminUsername { get; set; }
        public string SqlAdminPassword { get; set; }
    }
}
