using Microsoft.AspNetCore.Mvc;

namespace BeerShop.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
