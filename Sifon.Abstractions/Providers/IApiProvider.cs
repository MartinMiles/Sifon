using System.Threading.Tasks;

namespace Sifon.Abstractions.Providers
{
    public interface IApiProvider
    {
        Task<U> SendFeedback<T, U>(T t);
    }
}
