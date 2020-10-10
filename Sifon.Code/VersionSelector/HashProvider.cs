using System;
using System.IO;
using System.Security.Cryptography;

namespace Sifon.Code.VersionSelector
{
    public class HashProvider
    {
        public string CalculateMD5(string filename)
        {
            if (!File.Exists(filename))
            {
                return null;
            }

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
