using BeerShop.Models;

namespace BeerShop.ViewModels
{
    public class BeerListViewModel
    {
        public string? SearchString { get; set; }
        public IEnumerable<Beer> Beers { get;  }
        
        public IEnumerable<Category> Categories { get; }
        public BeerListViewModel(IEnumerable<Beer> beers, IEnumerable<Category> categories)
        {
            Beers = beers;
            Categories = categories;
        }
    }
}
