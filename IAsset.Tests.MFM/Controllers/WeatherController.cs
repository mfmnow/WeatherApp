using System.Web.Http;

using IAsset.Tests.MFM.Contracts;

namespace IAsset.Tests.MFM.Controllers
{
    [RoutePrefix("api")]
    public class WeatherController : ApiController
    {
        private readonly IWeatherHandler _weatherHandler;

        public WeatherController(IWeatherHandler weatherHandler)
        {
            _weatherHandler = weatherHandler;
        }

        [Route("GetWeather")]
        [HttpGet]
        public object GetWeather(string country, string city)
        {
            string imode = "";
            string ijson = _weatherHandler.GetWeatherJSON(country, city, out imode);
            return new { mode=imode, json= ijson };
        }
    }
}
