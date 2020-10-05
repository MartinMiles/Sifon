namespace Sifon.Abstractions.Model.BackupRestore
{
    public interface IDatabase
    {
        bool ProcessDatabases { get; }
        string[] Databases { get; }
    }
}
