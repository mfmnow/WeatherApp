using System.Web.Http;

using DryIoc;
using DryIoc.Mvc;
using DryIoc.WebApi;

using IAsset.Tests.MFM.Contracts;
using IAsset.Tests.MFM.Classes;


namespace IAsset.Tests.MFM.App_Start
{
    public class DryIOCConfigBuilder
    {
        private readonly IContainer _container;
        public DryIOCConfigBuilder(IContainer container)
        {
            _container = container;
        }

        public void BuildIOCConfig(HttpConfiguration httpConfig)
        {
            _container.Register<ICountriesHandler, CountriesHandler>();
            _container.Register<IHomeViewModel, HomeViewModel>();
            _container.Register<ICitiesHandler, CitiesHandler>();
            _container.Register<IWeatherHandler, WeatherHandler>();

            _container.UseInstance<ICache>(new Cache());

            _container.WithMvc();
            _container.WithWebApi(httpConfig);
        }
    }
}