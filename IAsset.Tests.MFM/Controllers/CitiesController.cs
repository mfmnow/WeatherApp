using System.Web.Http;

using IAsset.Tests.MFM.Contracts;

namespace IAsset.Tests.MFM.Controllers
{
    [RoutePrefix("api")]
    public class CitiesController : ApiController
    {
        private readonly ICitiesHandler _citiesHandler;
        

        public CitiesController(ICitiesHandler citiesHandler, IWeatherHandler weatherHandler)
        {
            _citiesHandler = citiesHandler;
        }

        [Route("GetCities")]
        [HttpGet]
        public object GetCities(string country)
        {
             return _citiesHandler.GetCitiesJSON(country);
        }
    }
}
