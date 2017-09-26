using Microsoft.VisualStudio.TestTools.UnitTesting;
using IAsset.Tests.MFM.Classes;


namespace IAsset.Test.MFM.UnitTesting
{
    [TestClass]
    public class CountriesHandlerTest
    {
        [TestMethod]
        public void Test_GetCountries()
        {
            var countriesHandler = new CountriesHandler(new Cache());
            var _countries = countriesHandler.GetCountries();

            Assert.IsTrue(_countries!=null);
            Assert.IsTrue(_countries.Count>0);
        }

        [TestMethod]
        public void Test_GetCountriesValues()
        {
            var countriesHandler = new CountriesHandler(new Cache());
            var _countries = countriesHandler.GetCountries();

            Assert.IsTrue(_countries.ContainsKey("EG"));
            Assert.IsTrue(!_countries.ContainsKey("Egypt123"));
        }
    }

}
