namespace Sifon.Abstractions.Profiles
{
    public interface ICrashDetails
    {
        bool SendCrashDetails { get; set; }
        string PluginsRepository { get; set; }
        bool AlignVersions{ get; set; }
    }
}
