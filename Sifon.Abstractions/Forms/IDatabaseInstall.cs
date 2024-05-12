namespace Sifon.Abstractions.Forms
{
    public interface IDatabaseInstall
    {
        string Edition { get; set; }
        string Version { get; set; }
        string Instance { get; set; }
        string Password { get; set; }
    }
}
