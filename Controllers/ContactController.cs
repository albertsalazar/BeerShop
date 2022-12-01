using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BeerShop.Controllers
{
    [Authorize]
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
