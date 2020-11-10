namespace Sifon.Abstractions.Model
{
    public interface ISolrInfo
    {
        string Url { get; set; }
        string Version { get; set; }
        string Directory { get; set; }
    }
}
