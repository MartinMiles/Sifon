namespace Sifon.Shared.Code.Downloader
{
    public class Resource
    {
        public string code { get; set; }
        public string url { get; set; }
        public string path { get; set; }
        public long size{ get; set; }

        public override string ToString()
        {
            return path;
        }
    }
}
