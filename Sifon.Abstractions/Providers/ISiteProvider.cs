using System.Collections.Generic;
using System.Threading.Tasks;
using Sifon.Abstractions.Model.Response;

namespace Sifon.Abstractions.Providers
{
    public interface ISiteProvider
    {
        Task<IEnumerable<string>> GetSitecoreSites();

        Task<IEnumerable<KeyValuePair<string, string>>> GetBindings(string siteName);
        Task<string> GetSitePath(string siteName);
        Task<string> GetXconnect(string siteName);
        Task<string> GetIDS(string siteName);
        Task<string> GetHorizon(string siteName);
        Task<string> GetPublishingService(string siteName);
        Task<IScriptWrapperResponse<string>> GetDatabases(string serverInstance, string instancePrefix);
        Task<IEnumerable<string>> GetCommerceSites(string siteName);
        Task<IScriptWrapperResponse<string>> GetCommerceDatabases(string siteName);
    }
}
