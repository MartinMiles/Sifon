using System.Collections.Generic;
using Sifon.Abstractions.Profiles;

namespace Sifon.Abstractions.Providers
{
    public interface ISettingsProvider
    {
        ISettingRecord Read();
        void SaveCredentials(IPortalCredentials portalCredentials);
        void SaveCrashDetails(ICrashDetails crashDetails);
        void AddScriptSettingsParameters(IDictionary<string, object> parameters);
        void TestScriptSettingsParameters(IDictionary<string, object> parameters, string username, string password);
    }
}
