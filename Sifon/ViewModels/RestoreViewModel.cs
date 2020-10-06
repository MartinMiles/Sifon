using Sifon.Abstractions.Model.BackupRestore;

namespace Sifon.ViewModels
{
    internal class RestoreViewModel : BackupRemoverViewModel, IRestoreViewModel
    {
        public string WebsiteZip { get; set; }
        public string XConnectZip { get; set; }
        public string IdentityZip { get; set; }
        public string HorizonZip { get; set; }
        public string PublishingZip { get; set; }
    }
}
