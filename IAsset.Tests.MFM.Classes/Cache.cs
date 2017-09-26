using System.Collections.Generic;
using IAsset.Tests.MFM.Contracts;

namespace IAsset.Tests.MFM.Classes
{
    public class Cache : ICache
    {
        public IDictionary<string, object> Items { get; set; }

        public Cache()
        {
            Items = new Dictionary<string, object>();
        }

        public object GetCacheItem(string key)
        {
            if (Items.ContainsKey(key))
                return Items[key];
            return null;
        }

        public void SetCacheItem(string key, object value)
        {
            Items[key] = value;
        }
    }
}
