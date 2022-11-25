using BeerShop.Models;
using BeerShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BeerShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBeerRepository _beerRepository;

        public HomeController(IBeerRepository beerRepository)
        {
            _beerRepository = beerRepository;
        }

        public IActionResult Index()
        {
            var sponsoredBeers = _beerRepository.SponsoredBeers;
            var homeViewModel = new HomeViewModel(sponsoredBeers);
            return View(homeViewModel);
        }
    }
}
