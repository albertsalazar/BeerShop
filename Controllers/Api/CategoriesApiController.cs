using BeerShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeerShop.Controllers.Api
{
    [Route("api/SearchCategories")]
    [ApiController]
    public class CategoriesApiController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesApiController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var allCategories = _categoryRepository.GetAll;
            return Ok(allCategories);

        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if (!_categoryRepository.GetAll.Any(c => c.CategoryId == id))
                return NotFound();

            return Ok(_categoryRepository.GetAll.Where(c => c.CategoryId == id));
        }
    }
}

