using BeerShop.Models;
using BeerShop.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BeerShop.Controllers
{
    public class BeerController : Controller
    {
        private readonly IBeerRepository _beerRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly BeerShopDbContext _context;

        public BeerController(IBeerRepository beerRepository, ICategoryRepository categoryRepository, BeerShopDbContext context)
        {
            _beerRepository = beerRepository;
            _categoryRepository = categoryRepository;
            _context = context;
        }

        public IActionResult List()
        {
            BeerListViewModel beerListViewModel = new BeerListViewModel(_beerRepository.GetAll, _categoryRepository.GetAll);
            return View(beerListViewModel);
        }

        public IActionResult Details(int id)
        {
            var beer = _beerRepository.Get(id);
            if(beer == null)
            {
                return NotFound();
            }
            var detailViewModel = new DetailViewModel(beer);
            return View(detailViewModel);
        }
        public IActionResult SearchForCategory(int id)
        {
            BeerListViewModel beerListViewModel = new BeerListViewModel(_beerRepository.GetBeersByCategory(id), _categoryRepository.GetAll);
            return View(beerListViewModel);
        }
        [Authorize]
        public IActionResult Create()
        {
            Beer beer = new Beer();
            BeerCreateViewModel beerCreateViewModel = new BeerCreateViewModel(_categoryRepository.GetAll, beer);
            

            return View(beerCreateViewModel);

        }
        [Authorize]
        [HttpPost]
        public IActionResult Create(Beer beer)
        {
            if (ModelState.IsValid)
            {
                _beerRepository.AddBeer(beer);
                return RedirectToAction("List");
            }
            return View(beer);
        }
        [Authorize]
        public IActionResult DeleteBeer(int Id)
        {
            _beerRepository.DeleteBeer(Id);
            return RedirectToAction("List");

        }
        [Authorize]
        public IActionResult UpdateBeer(int id)
        {
            Beer beer = _context.Beers.FirstOrDefault(b => b.Id == id);
            if(beer == null)
            {
                return NotFound();
            }
            BeerCreateViewModel beerCreateViewModel = new BeerCreateViewModel(_categoryRepository.GetAll, beer);
            return View(beerCreateViewModel);
        }

        [Authorize]
        public IActionResult UpdateBeerAction(Beer beer)
        {
            if (ModelState.IsValid)
            {
                _beerRepository.UpdateBeer(beer);
                return RedirectToAction("List");
            }
            return  RedirectToAction("UpdateBeer");
        }
        [HttpGet]
        public IActionResult SearchBeers(string? searchString)
        {
            IEnumerable<Beer> beers = new List<Beer>();
            if (!string.IsNullOrEmpty(searchString))
            {
                beers = _beerRepository.SearchBeers(searchString);
                BeerListViewModel beerListViewModelForSearch = new BeerListViewModel(beers, _categoryRepository.GetAll);
                return View(beerListViewModelForSearch);
            }

            return RedirectToAction("List");
        }
        
    }
}
