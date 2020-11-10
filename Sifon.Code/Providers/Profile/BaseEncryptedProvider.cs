using Sifon.Abstractions.Encryption;
using Sifon.Code.Encryption;

namespace Sifon.Code.Providers.Profile
{
    internal class BaseEncryptedProvider
    {
        protected readonly IEncryptor Encryptor;

        protected BaseEncryptedProvider()
        {
            Encryptor = new Encryptor();
        }
    }
}
