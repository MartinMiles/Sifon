using System;
using System.IO;
using System.Security;
using System.Text.RegularExpressions;
using Sifon.Code.Statics;

namespace Sifon.Code.Extensions
{
    public static class StringExtensions
    {
        public static bool Compare(this string leftString, string caseInsensitiveString)
        {
            return String.Equals(leftString, caseInsensitiveString, StringComparison.OrdinalIgnoreCase);
        }
        public static bool NotEmpty(this string stringValue)
        {
            return !string.IsNullOrWhiteSpace(stringValue);
        }

        public static bool IsValidFilePath(this string filePath)
        {
            try
            {
                if (Regex.IsMatch(filePath, ".+\\.[\\w]{1,10}$"))
                {
                    Path.GetFullPath(filePath);
                    return true;
                }
            }
            catch (Exception)
            {
            }
            return false;

        }

        public static bool IsRelativePath(this string filePath)
        {
            return Regex.IsMatch(filePath, "^\\/[^\\/]+\\/[^\\/].*$|^\\/[^\\/].*$");
        }

        public static bool IsValidDirectoryPath(this string filePath)
        {
            try
            {
                if (!Path.IsPathRooted(filePath)) return false;

                if (File.Exists(filePath) && !File.GetAttributes(filePath).HasFlag(FileAttributes.Directory))
                {
                    return false;
                }

                Path.GetFullPath(filePath);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static string TrimEnd(this string source, string value)
        {
            return source.EndsWith(value)
                ? source.Remove(source.LastIndexOf(value))
                : source;
        }

        public static SecureString ToSecureString(this string plainString)
        {
            if (plainString == null)
            {
                return null;
            }

            var secureString = new SecureString();
            foreach (char c in plainString)
            {
                secureString.AppendChar(c);
            }

            return secureString;
        }
    }
}
