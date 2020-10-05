using System.Collections.Generic;

namespace Sifon.Abstractions.Model.BackupRestore
{
    public interface IBackupRestoreFolders
    {
        string WebsiteFolder { get; }

        string IdentityFolder { get; }

        string XConnectFolder { get; }

        string HorizonFolder { get; }

        string PublishingFolder { get; }

        Dictionary<string, string> CommerceSites { get; }
    }
}
