namespace Sifon.Abstractions.Forms
{
    public interface ISolrInstall
    {
        string Version { get; set; }
        string Hostname { get; set; }
        string Port { get; set; }
        string Folder { get; set; }
    }
}
