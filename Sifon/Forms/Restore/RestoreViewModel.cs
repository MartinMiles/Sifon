using Sifon.Abstractions.Model.BackupRestore;
using Sifon.Forms.Backup;

namespace Sifon.Forms.Restore
{
    public class RestoreViewModel : BackupRemoverViewModel, IRestore
    {
        public string WebsiteZip { get; set; }
        public string XConnectZip { get; set; }
        public string IdentityZip { get; set; }
        public string HorizonZip { get; set; }
        public string PublishingZip { get; set; }

        public bool ProcessDatabases { get; set; }
        public string[] Databases { get; set; }


        // TODO: review these below. Also acces modifiers
        public string DestinationFolder { get; set; }

    }
}
