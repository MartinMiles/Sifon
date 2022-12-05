using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Sifon.Code.Extensions
{
    public static class ObjectExtensions
    {
        public static IDictionary<string, T> ToDictionary<T>(this object source)
        {
            if (source == null) ThrowExceptionWhenSourceArgumentIsNull();

            var dictionary = new Dictionary<string, T>();

            PropertyDescriptorCollection properties;
            try
            {
                properties = TypeDescriptor.GetProperties(source);
            }
            catch (Exception e)
            {
                properties = TypeDescriptor.GetProperties(source);
            }

            foreach (PropertyDescriptor property in properties)
            {
                object value = property.GetValue(source);
                if (IsOfType<T>(value))
                {
                    dictionary.Add(property.Name, (T)value);
                }
            }
            return dictionary;
        }

        private static bool IsOfType<T>(object value)
        {
            return value is T;
        }

        private static void ThrowExceptionWhenSourceArgumentIsNull()
        {
            throw new NullReferenceException("Unable to convert anonymous object to a dictionary. The source anonymous object is null.");
        }
    }
}
