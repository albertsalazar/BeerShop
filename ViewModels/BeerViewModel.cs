namespace BeerShop.ViewModels
{
    public class BeerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UrlImagen { get; set; }
        public decimal Price { get; set; }
        public bool InStock { get; set; }
        public int CategoryId { get; set; }
        public bool IsSponsoredBeer { get; set; }
    }
}
