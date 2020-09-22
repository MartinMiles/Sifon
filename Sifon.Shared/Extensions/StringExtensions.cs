using System;
using System.IO;
using System.Security;

namespace Sifon.Shared.Extensions
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
                var path = Path.GetFullPath(filePath);
                return true;
            }
            //catch (PathTooLongException ex)
            catch (Exception ex)
            {
                return false;
            }
        }
        public static string TrimEnd(this string source, string value)
        {
            if (!source.EndsWith(value))
                return source;

            return source.Remove(source.LastIndexOf(value));
        }

        public static SecureString ToSecureString(this string plainString)
        {
            if (plainString == null)
            {
                return null;
            }

            var secureString = new SecureString();
            foreach (char c in plainString.ToCharArray())
            {
                secureString.AppendChar(c);
            }

            return secureString;
        }
    }
}
