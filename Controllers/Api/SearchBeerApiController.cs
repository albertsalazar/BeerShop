using BeerShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace BeerShop.Controllers.Api
{
    [Route("api/search")]
    [ApiController]
    public class SearchBeerApiController:   ControllerBase
    {
        private readonly IBeerRepository _beerRepository;
        public SearchBeerApiController(IBeerRepository beerRepository)
        {
            _beerRepository = beerRepository;

        }
        [HttpGet]
        public IActionResult SearchBeers(string? searchQuery)
        {
            IEnumerable<Beer> beers = new List<Beer>();
            if (!string.IsNullOrEmpty(searchQuery))
            {
                beers = _beerRepository.SearchBeers(searchQuery);
            }
            return new JsonResult(beers);
        }
    }
}
