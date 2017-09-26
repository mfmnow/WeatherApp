using System.Xml;
using System.Collections.Generic;
using Newtonsoft.Json;

using IAsset.Tests.MFM.Contracts;

namespace IAsset.Tests.MFM.Classes
{
    public class CitiesHandler : ICitiesHandler
    {
        //TODO IOC GlobalWeatherSoap
        //private readonly GlobalWeather.GlobalWeatherSoap _client;
        public string GetCitiesJSON(string country)
        {
            GlobalWeather.GlobalWeatherSoapClient _client = new GlobalWeather.GlobalWeatherSoapClient();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(_client.GetCitiesByCountry(country));
            string jsonText = JsonConvert.SerializeXmlNode(doc);
            return jsonText;
        }
    }
}
