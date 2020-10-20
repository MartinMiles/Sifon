using System;
using System.Text.RegularExpressions;

namespace Sifon.Code.Model
{
    public class ProductVersion
    {
        public ProductVersion(string version)
        {
            var regex = new Regex("\\s*(\\d)\\.(\\d{2})\\s*");

            var match = regex.Match(version);
            if (match.Success)
            {

                int majorVersion = int.TryParse(match.Groups[1].Value, out majorVersion) ? majorVersion : -1;
                int minorVersion = int.TryParse(match.Groups[2].Value, out minorVersion) ? minorVersion : -1;

                if (majorVersion >= 0 && minorVersion >= 0)
                {
                    Major = majorVersion;
                    Minor = minorVersion;
                    return;
                }
            }

            throw new ApplicationException("Version provided with incorrect format");
        }

        public static bool operator >=(ProductVersion a, ProductVersion b)
        {
            if (a.Major == b.Major)
            {
                return a.Minor >= b.Minor;
            }

            return a.Major > b.Major;
        }

        public static bool operator <=(ProductVersion a, ProductVersion b)
        {
            if (a.Major == b.Major)
            {
                return a.Minor <= b.Minor;
            }

            return a.Major < b.Major;
        }

        public int Major { get; private set; }
        public int Minor { get; private set; }

        public override string ToString() => $"{Major}.{Minor.ToString("00")}";
    }
}
