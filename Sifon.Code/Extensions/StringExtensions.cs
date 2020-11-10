using System;
using System.IO;
using System.Security;

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
