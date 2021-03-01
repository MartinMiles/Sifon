using System.Collections.Generic;

namespace Sifon.Code.VersionSelector
{
    public static class Settings
    {
        public static List<KernelHash> Hashes => new List<KernelHash>
        {
            new KernelHash { Version = "0.0.0" },
            new KernelHash { Version = "9.0.2", Original = "7405e3c517ce09d6a2c1f003eba9834e" },
            new KernelHash { Version = "9.1.0", Original = "69f5809374d4f3aff22746a96ddc8c9f" },
            new KernelHash { Version = "9.1.1", Original = "78a87ff66bd077fb9cea89f114a0c03c" },
            new KernelHash { Version = "9.2.0", Original = "22cf534c9cdf9df1ff605dcb78e5ee72" },
            new KernelHash { Version = "9.3.0", Original = "aaa7b64372163d4da14a1568f42bbd61" },
            new KernelHash { Version = "10.0", Original = "28cbf1cba01a5c16d0fccf1548f2d98a" },
            new KernelHash { Version = "10.0.1", Original = "ece60d8414632ed563ef541d05e0cb91" },
            new KernelHash { Version = "10.1.0", Original = "5d3cf364ca04a04395f9e39db9d2d2ff" }
        };
    }
}