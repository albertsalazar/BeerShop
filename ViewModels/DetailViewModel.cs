using BeerShop.Models;

namespace BeerShop.ViewModels
{
    public class DetailViewModel
    {
        public Beer Beer { get; }

        public DetailViewModel(Beer beer)
        {
            Beer = beer;
        }
    }
}
