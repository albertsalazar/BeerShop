
using BeerShop.Models;
using BeerShop.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeerShop.Controllers.Api
{
    [Route("api/beers")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IBeerRepository _beerRepository;
        

        public SearchController(IBeerRepository beerRepository)
        {
            _beerRepository = beerRepository;
            
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var allBeers = _beerRepository.GetAll;
            return Ok(allBeers);

        }
        [HttpGet("{id}")]
        public IActionResult GetBeer(int id)
        {
            if (!_beerRepository.GetAll.Any(b => b.Id == id))
                return NotFound();
            
            return Ok(_beerRepository.GetAll.Where(b => b.Id == id)); 
        }
      
        [HttpPost]
        public async Task<ActionResult<Beer>> CreateBeer([FromBody] Beer beer)
        {
            try
            {
                if (beer == null)
                {
                    return BadRequest();
                }
                var createdBeer = await _beerRepository.AddBeer(beer);

                return CreatedAtAction(nameof(GetBeer),
                    new { id = createdBeer.Id }, createdBeer);
            }
            catch(Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Beer>> DeleteBeer(int id)
        {
            try
            {
                var beerToDelete = _beerRepository.Get(id);
                if(beerToDelete == null)
                {
                    return NotFound($"Beer with Id = {id} not found");

                }
                return _beerRepository.DeleteBeer(id);


            }catch(Exception e)
            {
                return StatusCode(500);
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Beer>> UpdateBeer(int id, Beer beer)
        {
            try
            {
                if( id != beer.Id)
                {
                    return BadRequest("Beer ID dismatch");
                }
                var beerToUpdate = _beerRepository.Get(id);

                if(beerToUpdate == null)
                {
                    return NotFound($"Beer with Id = {id} not found");
                }
                return _beerRepository.UpdateBeer(beer);
            }catch(Exception e)
            {
                return StatusCode(500);
            }

        }



    }
}
