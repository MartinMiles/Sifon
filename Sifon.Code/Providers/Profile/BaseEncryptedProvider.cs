using Sifon.Abstractions.Encryption;
using Sifon.Code.Encryption;

namespace Sifon.Code.Providers.Profile
{
    public class BaseEncryptedProvider
    {
        protected readonly IEncryptor Encryptor;

        public BaseEncryptedProvider()
        {
            Encryptor = new Encryptor();
        }
    }
}
