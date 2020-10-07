using System;
using System.Xml;

namespace Sifon.Code.Extensions
{
    public static class XmlExtension
    {
        internal delegate bool TryParse<T>(string str, out T value);

        public static bool BoolAttribute(this XmlNode node, string attributeName, bool defaultValue = false)
        {
            if (node.Attributes[attributeName] != null)
            {
                return node.Attributes[attributeName].Value.GetValue<bool>(bool.TryParse);
            }

            return defaultValue;
        }

        internal static T GetValue<T>(this string str, TryParse<T> parseFunc)
        {
            T val;
            parseFunc(str, out val);
            return val;
        }

        public static string StringAttribute(this XmlNode node, string attributeName)
        {
            if (node.Attributes[attributeName] != null)
            {
                return node.Attributes[attributeName].Value;
            }

            return string.Empty;
        }

        public static bool GetBoolValue(this XmlNodeList list, string tagName, string attributeName)
        {
            foreach (XmlNode node in list)
            {
                if (node.Name.Compare(tagName) && node.Attributes[attributeName] != null)
                {
                    bool value = bool.TryParse(node.Attributes[attributeName].Value, out value) ? value : false;
                    return value;
                }
            }

            return false;
        }

        public static string GetTextValue(this XmlNodeList list, string tagName, string attributeName)
        {
            foreach (XmlNode node in list)
            {
                if (node.Name.Compare(tagName) && node.Attributes[attributeName] != null)
                {
                    return node.Attributes[attributeName].Value.Trim();
                }
            }

            return String.Empty;
        }
    }
}
