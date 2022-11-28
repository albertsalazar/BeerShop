using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BeerShop.Models
{
    public class BeerShopDbContext : IdentityDbContext
    {
        public BeerShopDbContext(DbContextOptions<BeerShopDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; } 

        public DbSet<Beer>  Beers { get; set; }


    }
}
