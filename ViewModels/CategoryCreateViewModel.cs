using BeerShop.Models;

namespace BeerShop.ViewModels
{
    public class CategoryCreateViewModel
    {
        public Category Category { get; }
        
        public CategoryCreateViewModel(Category category)
        {
            Category = category;
        }

    }
}
