namespace BeerShop.Models
{
    public class Category
    {
        private readonly BeerShopDbContext _context;
        public int CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }
        
       
    }
}
