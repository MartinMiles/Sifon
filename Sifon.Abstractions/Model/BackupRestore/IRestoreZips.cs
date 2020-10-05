namespace Sifon.Abstractions.Model.BackupRestore
{
    public interface IRestoreZips
    {
        string WebsiteZip { get; }
        string XConnectZip { get; }
        string IdentityZip { get; }
        string HorizonZip { get; }
        string PublishingZip { get; }
    }
}
