using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using System.Configuration;

using IAsset.Tests.MFM.Contracts;

namespace IAsset.Tests.MFM.Classes
{
    public class CountriesHandler : ICountriesHandler
    {
        private readonly ICache _cache;
        private const string CACHE_KEY = "Countries";
        public CountriesHandler(ICache cache) {
            _cache = cache;
        }

        public IDictionary<string,string> GetCountries()
        {
            var _cached = _cache.GetCacheItem(CACHE_KEY);
            if (_cached == null)
            {
                var soaClient = new WebClient();
                var resp = soaClient.DownloadString(ConfigurationManager.AppSettings["MFM:westclicks.URL"]);
                var _countries = JsonConvert.DeserializeObject<IDictionary<string, string>>(resp);
                _cache.SetCacheItem(CACHE_KEY, _countries);
                return _countries;
            }
            else
                return (IDictionary<string, string>)_cached;
        }
    }
}
