﻿using System.ComponentModel;

namespace BeerShop.Models
{
    public class Beer
    {

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; } 

        public decimal Price { get; set; }

        public string? ImageUrl {get; set; }
         
        public bool InStock {get; set; }

        public int CategoryId { get; set; }


        public bool IsSponsoredBeer { get; set; }



    }

    
}
