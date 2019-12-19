using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sifon.Abstractions.Providers
{
    public interface  ISiteProvider
    {
        Task<IEnumerable<string>> GetSitecoreSites();

        Task<IEnumerable<KeyValuePair<string, string>>> GetBindings(string siteName);
        Task<string> GetSitePath(string siteName);
        Task<string> GetXconnect(string siteName);
        Task<string> GetIDS(string siteName);
        Task<IEnumerable<string>> GetCommerceSites(string siteName);
        Task<IEnumerable<string>> GetCommerceDatabases(string siteName);
        Task<IEnumerable<KeyValuePair<string, string>>> GetBindingsByPath(string webfolder);
    }
}
