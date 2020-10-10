using Sifon.Abstractions.VersionSelector;

namespace Sifon.Code.VersionSelector
{
    public class KernelHash : IKernelHash
    {
        public string Version { get; set; }
        public string File { get; set; }
        public string Original { get; set; }
        public string Ready { get; set; }
        public string Product => Version != "0.0.0" ? $"Sitecore {Version}" : "=== not detected ===";
    }
}