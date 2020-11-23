using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sifon.Abstractions.Helpers
{
    public interface IIndexFinder
    {
        Task<IEnumerable<string>> FindAll();
    }
}
