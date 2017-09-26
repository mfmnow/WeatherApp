using Microsoft.VisualStudio.TestTools.UnitTesting;
using IAsset.Tests.MFM.Classes;

namespace IAsset.Test.MFM.UnitTesting
{
    [TestClass]
    public class CitiesHandlerTest
    {
        [TestMethod]
        public void Test_GetCitiesJSON()
        {
            var citiesHandler = new CitiesHandler();
            var _cities = citiesHandler.GetCitiesJSON("Egypt");

            Assert.IsTrue(_cities.Length > 0);
        }
    }
}
