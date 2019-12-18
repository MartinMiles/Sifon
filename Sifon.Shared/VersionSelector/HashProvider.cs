using System;
using System.IO;
using System.Security.Cryptography;

namespace Sifon.Shared.VersionSelector
{
    public class HashProvider
    {
        public string CalculateMD5(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }
    }
}
