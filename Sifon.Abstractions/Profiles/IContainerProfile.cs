namespace Sifon.Abstractions.Profiles
{
    public interface IContainerProfile
    {
        bool Selected { get; set; }
        string ProfileName { get; set; }
        string Repository { get; set; }
        string Folder { get; set; }
        string AdminPassword { get; set; }
        string SaPassword { get; set; }
    }
}
