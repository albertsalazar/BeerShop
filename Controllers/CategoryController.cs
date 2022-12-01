using BeerShop.Models;
using BeerShop.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BeerShop.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IBeerRepository _beerRepository;
        private readonly BeerShopDbContext _context;

        public CategoryController(ICategoryRepository categoryRepository, IBeerRepository beerRepository, BeerShopDbContext context)
        {
            _categoryRepository = categoryRepository;
            _beerRepository = beerRepository;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public IActionResult List()
        {
            CategoryListViewModel categoryListViewModel = new CategoryListViewModel(_categoryRepository.GetAll);

            return View(categoryListViewModel);
        }
        [Authorize]
        public IActionResult Create()
        {
            Category category= new Category();
            CategoryCreateViewModel categoryCreateViewModel = new CategoryCreateViewModel(category);


            return View(categoryCreateViewModel);

        }
        [Authorize]
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryRepository.AddCategory(category);
                return RedirectToAction("List");
            }
            return View(category);
        }
        [Authorize]
        public IActionResult DeleteCategory(int Id)
        {
            IEnumerable<Beer> beers = _beerRepository.GetBeersByCategory(Id);
            foreach(Beer beer in beers)
            {
                _beerRepository.DeleteBeer(beer.Id);
            }
            _categoryRepository.DeleteCategory(Id);
            return RedirectToAction("List");

        }
        [Authorize]
        public IActionResult Update(int id)
        {
            Category category = _context.Categories.FirstOrDefault(c => c.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }
            CategoryCreateViewModel categoryCreateViewModel = new CategoryCreateViewModel(category);
            return View(categoryCreateViewModel);
        }
        [Authorize]
        public IActionResult UpdateCategoryAction(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryRepository.UpdateCategory(category);
                return RedirectToAction("List");
            }
            return RedirectToAction("UpdateBeer");
        }
    }
}
