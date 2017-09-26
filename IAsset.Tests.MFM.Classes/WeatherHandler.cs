using Newtonsoft.Json;
using System.Xml;
using System.Net;
using System.Configuration;

using IAsset.Tests.MFM.Contracts;

namespace IAsset.Tests.MFM.Classes
{
    public class WeatherHandler: IWeatherHandler
    {
        public string GetWeatherJSON(string country, string city, out string mode)
        {
            GlobalWeather.GlobalWeatherSoapClient _client = new GlobalWeather.GlobalWeatherSoapClient();
            XmlDocument doc = new XmlDocument();
            var result = _client.GetWeather(city, country);
            if (result == "Data Not Found")
            {
                var soaClient = new WebClient();
                mode = "openweathermap";
                return soaClient.DownloadString($"{ConfigurationManager.AppSettings["MFM:openweathermap.URL"]}?q={city},{country}&units=metric&appid={ConfigurationManager.AppSettings["MFM:openweathermap.Key"]}");
            }
            doc.LoadXml(result);
            mode = "GlobalWeather";
            return JsonConvert.SerializeXmlNode(doc);
        }
    }
}
