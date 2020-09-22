namespace Sifon.Abstractions.Profiles
{
    public interface ISettingRecord
    {
        string PortalUsername { get; }
        string PortalPassword { get; set; }
    }
}
