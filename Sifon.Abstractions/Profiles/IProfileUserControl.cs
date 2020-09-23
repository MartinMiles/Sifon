namespace Sifon.Abstractions.Profiles
{
    public interface IProfileUserControl
    {
        string ProfileName { get; }

        string Prefix { get; }

        string AdminUsername { get; }

        string AdminPassword { get; }
    }
}
