using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeerShop.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BeerShopDbContext _context;

        public CategoryRepository(BeerShopDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetAll =>
            _context.Categories.OrderBy(b => b.CategoryId);
        
        public Category? Get(int id)
        {
            return _context.Categories.FirstOrDefault(c => c.CategoryId == id);

        }

        [HttpPost]
        public async Task<Category> AddCategory(Category category)
        {
            var result = await _context.Categories.AddAsync(category);
            _context.SaveChanges();
            return result.Entity;
        }
        public Category DeleteCategory(int id)
        {
            var result = _context.Categories.FirstOrDefault(c => c.CategoryId == id);
            if (result != null)
            {
                _context.Categories.Remove(result);
                _context.SaveChanges();
                return result;
            }
            return null;
        }
        public Category UpdateCategory(Category category)
        {
            var result = _context.Categories.FirstOrDefault(c => c.CategoryId == category.CategoryId);
            if (result != null)
            {
                result.Name = category.Name;
                result.Description = category.Description;
                
                _context.SaveChanges();
                return result;
            }
            return null;

        }
       
    }
   
}
