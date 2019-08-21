using System.Collections.Generic;

namespace Sifon.Plugins.Example.VisualPlugin.Code
{
    public sealed class Pair<TKey, TValue>
    {
        private readonly TKey key;
        private readonly IDictionary<TKey, TValue> data;

        public Pair(TKey key, IDictionary<TKey, TValue> data)
        {
            this.key = key;
            this.data = data;
        }
        public TKey Key => key;

        public TValue Value
        {
            get
            {
                data.TryGetValue(key, out var value);
                return value;
            }
            set => data[key] = value;
        }
    }
}
