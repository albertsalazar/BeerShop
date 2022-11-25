namespace BeerShop.Models
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll { get; }

    }
}
