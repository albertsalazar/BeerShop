namespace BeerShop.Models
{
    public class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            BeerShopDbContext context = applicationBuilder.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<BeerShopDbContext>();
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(Categories.Select(c => c.Value));
            }
            if (!context.Beers.Any())
            {
                context.AddRange(
                    new Beer { Name = "Cruzcampo", Price = 1.50M, Description = "Clásica lager andaluza", ImageUrl = "#", InStock = true, IsSponsoredBeer=true },
                    new Beer { Name = "Cruzcampo Especial", Price= 1.70M, Description="La edición lager especial de cruzcampo", ImageUrl="#", InStock= true, IsSponsoredBeer = true },
                    new Beer { Name = "1906 Indian Pale Ale", Price = 1.50M, Description= "Cerveza de estrella galicia, estilo indian pale ale", ImageUrl="#", InStock=true, IsSponsoredBeer = true }
                );
            }
            context.SaveChanges();

        }
        private static Dictionary<string, Category>? categories;

        public static Dictionary<string, Category> Categories
        {
            get
            {
                if(categories == null)
                {
                    var genresList = new Category[]
                    {
                        new Category{Name="Lager"},
                        new Category{Name="Pale Ale"},
                        new Category{Name="Lager especial"}
                    };
                    categories = new Dictionary<string, Category>();

                    foreach(Category category in genresList)
                    {
                        categories.Add(category.Name, category);
                    }
                }
                return categories;
            }
        }
    }
}
