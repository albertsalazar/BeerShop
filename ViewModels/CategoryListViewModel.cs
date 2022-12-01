using BeerShop.Models;

namespace BeerShop.ViewModels
{
    public class CategoryListViewModel
    {
        public IEnumerable<Category> Categories { get; }
        public CategoryListViewModel(IEnumerable<Category> categories)
        {
            Categories = categories;
            
        }
    }
}
