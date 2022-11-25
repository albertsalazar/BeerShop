using BeerShop.Controllers.Api;
using Microsoft.EntityFrameworkCore;

namespace BeerShop.Models
{
    public class BeerRepository : IBeerRepository
    {
        private readonly BeerShopDbContext _context;

        public BeerRepository(BeerShopDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Beer> GetAll
        {
            get
            {
                return _context.Beers;
            }
        }

        public Beer? Get(int id)
        {
            return _context.Beers.FirstOrDefault(b => b.Id == id);
        }

        public IEnumerable<Beer> SponsoredBeers
        {
            get
            {
                return _context.Beers.Where(b => b.IsSponsoredBeer);
            }
        }
        public IEnumerable<Beer> GetBeersByCategory(int Id)
        {
            
                return _context.Beers.Where(b => b.CategoryId == Id);
            
        }

        public void AddEntity(Beer model)
        {
            _context.Add(model);
            
            
        }
        public bool SaveAll()
        {
     
            _context.SaveChanges();

            if(_context.SaveChanges() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Beer> AddBeer(Beer beer)
        {
            var result = await _context.Beers.AddAsync(beer);
            _context.SaveChanges();
            
            return result.Entity;
        }
        public Beer DeleteBeer(int id)
        {
            var result = _context.Beers.FirstOrDefault(b => b.Id == id);
            if(result != null)
            {
                _context.Beers.Remove(result);
                _context.SaveChanges();
                return result;
            }
            return null;
        }

        public Beer UpdateBeer(Beer beer)
        {
            var result = _context.Beers.FirstOrDefault(b => b.Id == beer.Id);
            if(result != null)
            {
                result.Name = beer.Name;
                result.Description = beer.Description;
                result.Price = beer.Price;
                result.IsSponsoredBeer = beer.IsSponsoredBeer;
                result.InStock = beer.InStock;
                result.CategoryId = beer.CategoryId;
                result.ImageUrl = beer.ImageUrl;

                _context.SaveChanges();
                return result;
            }
            return null;

        }
       
    }
}
