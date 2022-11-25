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
            _context.Categories.OrderBy(b => b.Name);
    }
}
