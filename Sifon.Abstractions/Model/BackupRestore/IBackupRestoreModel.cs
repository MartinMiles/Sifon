using System.Collections.Generic;

namespace Sifon.Abstractions.Model.BackupRestore
{
    public interface IBackupRestoreModel
    {
        EmbeddedActivity EmbeddedActivity { get; }
        string DestinationFolder { get; }
        string SitecoreInstance { get; }
        bool ProcessDatabases { get; }
        bool ProcessWebroot { get; }
        bool ProcessXconnect { get; }
        bool ProcessIDS { get; }
        bool ProcessCommerce { get; }
        string XConnect { get; }
        string IdentityServer { get; }
        string XConnectFolder { get; }
        string IdentityServerFolder { get; }
        IEnumerable<KeyValuePair<string, string>> CommerceSites { get; }
        string[] SelectedDatabases { get; }
    }
}
