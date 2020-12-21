using System.Threading.Tasks;

namespace Sifon.Abstractions.Helpers
{
    public interface IRequestHelper
    {
        Task<string> ReadUrlContent(string url);
    }
}
