namespace Sifon.Abstractions.Model.BackupRestore
{
    public interface IBackupRestoreCheckboxes
    {
        bool WebsiteChecked { get;  }

        bool IdentityChecked { get; }

        bool XConnectChecked { get; }

        bool HorizonChecked { get; }

        bool PublishingChecked { get; }

        bool CommerceChecked { get; }
    }
}
