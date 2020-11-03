namespace Sifon.Abstractions.Profiles
{
    public interface IContainerProfile
    {
        bool Selected { get; set; }
        string ContainerProfileName { get; set; }
        string Repository { get; set; }
        string Folder { get; set; }
        string SitecoreAdminPassword { get; set; }
        string SaPassword { get; set; }
        string InitializeScript { get; set; }
        string Notes { get; set; }
    }
}
