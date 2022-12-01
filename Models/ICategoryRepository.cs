namespace BeerShop.Models
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll { get; }

        Task<Category> AddCategory(Category category);

        Category Get(int id);
        Category DeleteCategory(int id);
        Category UpdateCategory(Category category);
    }
}
