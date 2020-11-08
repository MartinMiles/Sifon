using System.Collections.Generic;
using Sifon.Abstractions.Model.BackupRestore;
using Sifon.Abstractions.Profiles;

namespace Sifon.Abstractions.Providers
{
    public interface IProfilesProvider
    {
        IProfile SelectedProfile { get; }
        ISqlServerRecord SelectedProfileSql { get; }

        bool Any { get; }

        void SelectProfile(string selectedProfileName);

        IEnumerable<IProfile> Read();
        void Save();

        IProfile CreateLocal();
        IProfile CreateProfile();
        IProfile CreateProfile(IRemoteSettings remoteSettings);

        void Add(IProfileUserControl p);
        void UpdateSelected(IProfile profile);
        void DeleteSelected();

        void AddScriptProfileParameters(Dictionary<string, dynamic> parameters);
        void AddBackupRemoveParameters(Dictionary<string, dynamic> parameters, IBackupRemoverViewModel model);
        void AddRestoreParameters(Dictionary<string, dynamic> parameters, IRestoreZips model);

        void AddCommerceScriptParameters(Dictionary<string, dynamic> parameters, IEnumerable<KeyValuePair<string, string>> commerceSites);

        void AssignSqlServer(string recordName);
        string FindPrefixByName(string siteName);
    }
}
