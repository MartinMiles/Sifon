namespace Sifon.Abstractions.Profiles
{
    public interface IRemoteSettings
    {
        bool RemotingEnabled { get; set; }
        string RemoteHost { get; set; }
        string RemoteUsername { get; set; }
        string RemotePassword { get; set; }
        string RemoteFolder { get; set; }
    }
}
