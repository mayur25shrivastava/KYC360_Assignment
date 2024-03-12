using Microsoft.AspNetCore.Mvc;

namespace KYC360API.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Content("Hello!");
        }
    }
}
