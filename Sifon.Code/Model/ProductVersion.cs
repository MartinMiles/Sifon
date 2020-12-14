using System;
using System.Text.RegularExpressions;

namespace Sifon.Code.Model
{
    public class ProductVersion
    {
        #region Constructors

        public ProductVersion()
        {
        }

        public ProductVersion(string version)
        {
            var regex = new Regex("\\s*(\\d)\\.(\\d)\\.(\\d)(\\w?)\\s*");

            var match = regex.Match(version);
            if (match.Success)
            {

                int majorVersion = int.TryParse(match.Groups[1].Value, out majorVersion) ? majorVersion : -1;
                int middleVersion = int.TryParse(match.Groups[2].Value, out middleVersion) ? middleVersion : -1;
                int minorVersion = int.TryParse(match.Groups[3].Value, out minorVersion) ? minorVersion : -1;
                char alphaChar = char.TryParse(match.Groups[4].Value, out alphaChar) ? alphaChar : Char.MinValue;

                if (majorVersion >= 0 && minorVersion >= 0)
                {
                    Major = majorVersion;
                    Middle= middleVersion;
                    Minor = minorVersion;
                    Alpha = alphaChar != Char.MinValue && char.ToUpperInvariant(alphaChar) == 'A';
                    return;
                }
            }

            throw new ApplicationException("Version provided with incorrect format");
        }

        #endregion

        public static bool operator >=(ProductVersion a, ProductVersion b)
        {
            if (a.Major == b.Major)
            {
                if (a.Middle == b.Middle)
                {
                    if (a.Minor == b.Minor)
                    {
                        return !(a.Alpha && !b.Alpha);
                    }

                    return a.Minor > b.Minor;
                }

                return a.Middle > b.Middle;
            }

            return a.Major > b.Major;
        }

        public static bool operator <=(ProductVersion a, ProductVersion b)
        {
            if (a.Major == b.Major)
            {
                if (a.Middle == b.Middle)
                {
                    if (a.Minor == b.Minor)
                    {
                        return !(!a.Alpha && b.Alpha);
                    }

                    return a.Minor <= b.Minor;
                }

                return a.Middle <= b.Middle;
            }

            return a.Major < b.Major;
        }

        public int Major { get; set; }
        public int Middle { get; set; }
        public int Minor { get; set; }
        public bool Alpha { get; set; }

        public string DownloadUrl
        {
            get => $"/download/Sifon_{ToString()}.zip";
        }

        public override string ToString() => $"{Major}.{Middle}.{Minor}{(Alpha?"a":"")}";
    }
}
