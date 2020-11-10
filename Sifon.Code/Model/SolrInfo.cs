using Sifon.Abstractions.Model;

namespace Sifon.Code.Model
{
    public class SolrInfo : ISolrInfo
    {
        public string Url { get; set; }
        public string Version { get; set; }
        public string Directory { get; set; }
    }
}
