namespace Sifon.Abstractions.Model.BackupRestore
{
    public interface IBackupRemoverViewModel : IBackupRestoreFolders, IBackupRestoreCheckboxes, IDatabase
    {
        EmbeddedActivity EmbeddedActivity { get; }
        string DestinationFolder { get; }

    }
}
