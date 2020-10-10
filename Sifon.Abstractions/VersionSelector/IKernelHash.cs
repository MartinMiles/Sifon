namespace Sifon.Abstractions.VersionSelector
{
    public interface IKernelHash
    {
        string Version { get; set; }
        string Original { get; set; }
        string Product { get; }
    }
}
