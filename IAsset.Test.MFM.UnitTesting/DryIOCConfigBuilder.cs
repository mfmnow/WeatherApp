using DryIoc;

using IAsset.Tests.MFM.Contracts;
using IAsset.Tests.MFM.Classes;

namespace IAsset.Test.MFM.UnitTesting
{
    public class DryIOCConfigBuilder
    {
        public void BuildIOCConfig()
        {
            var _container = new Container();
            _container.Register<ICountriesHandler, CountriesHandler>();
            _container.Register<IHomeViewModel, HomeViewModel>();
            _container.Register<ICitiesHandler, CitiesHandler>();
            _container.Register<IWeatherHandler, WeatherHandler>();

            _container.UseInstance<ICache>(new Cache());
            
        }
    }
}
