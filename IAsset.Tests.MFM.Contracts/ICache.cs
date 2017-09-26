using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAsset.Tests.MFM.Contracts
{
    public interface ICache
    {
        IDictionary<string,object> Items { get; set; }
        void SetCacheItem(string key, object value);
        object GetCacheItem(string key);
    }
}
