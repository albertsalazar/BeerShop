using BeerShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeerShop.Controllers.Api
{
    [Route("api/categories")]
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
        public IActionResult GetCategory(int id)
        {
            if (!_categoryRepository.GetAll.Any(c => c.CategoryId == id))
                return NotFound();

            return Ok(_categoryRepository.GetAll.Where(c => c.CategoryId == id));
        }
        [HttpPost]
        public async Task<ActionResult<Beer>> CreateCategory([FromBody] Category category)
        {
            try
            {
                if (category == null)
                {
                    return BadRequest();
                }
                var createdCategory = await _categoryRepository.AddCategory(category);

                return CreatedAtAction(nameof(GetCategory),
                    new { id = createdCategory.CategoryId }, createdCategory);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Category>> DeleteCategory(int id)
        {
            try
            {
                var categoryToDelete = _categoryRepository.Get(id);
                if (categoryToDelete == null)
                {
                    return NotFound($"Category with Id = {id} not found");

                }
                return _categoryRepository.DeleteCategory(id);


            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Category>> UpdateCategory(int id, Category category)
        {
            try
            {
                if (id != category.CategoryId)
                {
                    return BadRequest("Category ID dismatch");
                }
                var categoryToUpdate = _categoryRepository.Get(id);

                if (categoryToUpdate == null)
                {
                    return NotFound($"Category with Id = {id} not found");
                }
                return _categoryRepository.UpdateCategory(category);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }

        }

    }
}

