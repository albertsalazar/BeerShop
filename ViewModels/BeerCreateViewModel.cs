using BeerShop.Models;

namespace BeerShop.ViewModels
{
    public class BeerCreateViewModel
    {
        

        public IEnumerable<Category> Categories { get; }

        public Beer Beer { get; }
        public BeerCreateViewModel(IEnumerable<Category> categories, Beer beer)
        {
            Categories = categories;
            Beer = beer;
        }
    }
}
