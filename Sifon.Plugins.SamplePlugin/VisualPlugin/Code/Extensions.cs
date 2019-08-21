using System.Collections.Generic;

namespace Sifon.Plugins.Example.VisualPlugin.Code
{
    public static class DictionaryExtensions
    {
        public static DictionaryBindingList<TKey, TValue> ToBindingList<TKey, TValue>(this IDictionary<TKey, TValue> data)
        {
            return new DictionaryBindingList<TKey, TValue>(data);
        }
    }
}
