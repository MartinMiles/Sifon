using System.Collections.Generic;
using System.Threading.Tasks;
using Sifon.Abstractions.PowerShell;

namespace Sifon.Abstractions.Providers
{
    public interface ISiteProvider
    {
        Task<IEnumerable<string>> GetSitecoreSites(bool isXM = false);

        Task<IEnumerable<KeyValuePair<string, string>>> GetBindings(string[] siteNames);
        Task<string> GetSitePath(string siteName);
        Task<string> GetXconnect(string siteName);
        Task<string> GetIDS(string siteName);
        Task<string> GetHorizon(string siteName);
        Task<string> GetPublishingService(string siteName);
        Task<IEnumerable<string>> GetDatabases(string serverInstance, string instancePrefix);
        Task<IEnumerable<string>> GetCommerceSites(string siteName);
        Task<IScriptWrapper<string>> GetCommerceDatabases(string siteName);
    }
}
