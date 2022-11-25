using BeerShop.Models;

namespace BeerShop.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Beer> SponsoredBeers { get; }

        public HomeViewModel(IEnumerable<Beer> sponsoredBeers)
        {
            SponsoredBeers = sponsoredBeers;
        }
    }
}
