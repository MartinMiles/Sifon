namespace Sifon.Abstractions.Encryption
{
    public interface IEncryptor
    {
        string Encrypt(string text);
        string Decrypt(string encryptedText);
    }
}
