using System.Web.Mvc;

using IAsset.Tests.MFM.Contracts;

namespace IAsset.Tests.MFM.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICountriesHandler _countriesHandler;
        private readonly IHomeViewModel _homeViewModel;
        
        public HomeController(ICountriesHandler countriesHandler, IHomeViewModel homeViewModel) {
            _countriesHandler = countriesHandler;
            _homeViewModel = homeViewModel;            
        }
        // GET: Home
        public ActionResult Index()
        {
            _homeViewModel.Countries = _countriesHandler.GetCountries();
            return View("Index", _homeViewModel);
        }
    }
}