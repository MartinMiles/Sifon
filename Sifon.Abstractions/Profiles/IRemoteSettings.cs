namespace Sifon.Abstractions.Profiles
{
    public interface IRemoteSettings
    {
        bool RemotingEnabled { get; }
        string RemoteHostname { get; }
        string RemoteUsername { get; }
        string RemotePassword { get; }
        string RemoteFolder { get; }
    }
}
