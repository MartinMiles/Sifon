namespace Sifon.Abstractions.Profiles
{
    public interface ISqlServerRecord
    {
        string RecordName { get; }

        string SqlServer { get; }

        string SqlAdminUsername { get; }

        string SqlAdminPassword { get; }
    }
}
