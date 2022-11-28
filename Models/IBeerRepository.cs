namespace BeerShop.Models
{
    public interface IBeerRepository
    {
        IEnumerable<Beer> GetAll { get; }
        
        Beer? Get(int id);

        IEnumerable<Beer> SponsoredBeers { get;  }
        IEnumerable<Beer> GetBeersByCategory(int id);
        void AddEntity(Beer model);
        bool SaveAll();

        Task<Beer> AddBeer(Beer beer);

        Beer DeleteBeer(int id);

        Beer UpdateBeer(Beer beer);

        IEnumerable<Beer> SearchBeers(string searchQuery);
    }
}
