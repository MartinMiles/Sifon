using System.Collections.Generic;

namespace Sifon.Abstractions.Model.BackupRestore
{
    public interface IBackupRestoreFolders
    {
        string WebsiteFolder { get; set; }

        string IdentityFolder { get; set; }

        string XConnectFolder { get; set; }

        string HorizonFolder { get; set; }

        string PublishingFolder { get; set; }

        Dictionary<string, string> CommerceSites { get; set; }
    }
}
