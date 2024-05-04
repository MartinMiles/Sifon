namespace Sifon.Abstractions.Profiles
{
    public interface IProfileUserControl
    {
        bool IsXM { get; set; }

        string ProfileName { get; set; }

        string Prefix { get; set; }

        string AdminUsername { get; set; }

        string AdminPassword { get; set; }
    }
}
