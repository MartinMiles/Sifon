namespace Sifon.Abstractions.Forms
{
    public interface IDatabaseInstall
    {
        string Edition { get; set; }
        string Version { get; set; }
        string SqlServer { get; set; }
        string SqlAdminPassword { get; set; }
    }
}
