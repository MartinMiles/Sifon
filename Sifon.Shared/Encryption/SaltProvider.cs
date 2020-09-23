using System.Security;
using System.Management;
using Sifon.Shared.Extensions;

namespace Sifon.Shared.Encryption
{
    internal class SaltProvider
    {
        internal SecureString GenerateSaltPassword()
        {
            var password = UUID.ToSecureString();
            password.AppendChar((char)80); // P
            password.AppendChar((char)97); // a
            password.AppendChar((char)115); // s
            password.AppendChar((char)115); // s
            password.AppendChar((char)119); // w
            password.AppendChar((char)111); // o
            password.AppendChar((char)114); // r
            password.AppendChar((char)100); // d
            password.AppendChar((char)50); // 2
            return password;
        }

        internal string UUID
        {
            get
            {
                string uuid = string.Empty;

                var managementClass = new ManagementClass("Win32_ComputerSystemProduct");
                var managementObjectCollection = managementClass.GetInstances();

                foreach (ManagementObject mo in managementObjectCollection)
                {
                    uuid = mo.Properties["UUID"].Value.ToString();
                    break;
                }

                return uuid;
            }
        }
    }
}
