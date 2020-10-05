using System.Collections.Generic;
using Sifon.Abstractions.Model.BackupRestore;

namespace Sifon.Forms.Backup
{
    public class BackupRemoverViewModel : IBackupRemoverViewModel
    {
        public EmbeddedActivity EmbeddedActivity { get; set; }
        public string DestinationFolder { get; set; }

        public bool WebsiteChecked { get; set; }
        public string WebsiteFolder { get; set; }

        public bool IdentityChecked { get; set; }
        public string IdentityFolder { get; set; }

        public bool XConnectChecked { get; set; }
        public string XConnectFolder { get; set; }

        public bool HorizonChecked { get; set; }
        public string HorizonFolder { get; set; }

        public bool PublishingChecked { get; set; }
        public string PublishingFolder { get; set; }

        public bool CommerceChecked { get; set; }
        public Dictionary<string, string> CommerceSites { get; set; }

        public bool ProcessDatabases { get; set; }
        public string[] Databases { get; set; }

    }
}
