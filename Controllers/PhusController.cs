using Microsoft.AspNetCore.Mvc;

namespace fullstackCsharp.Controllers
{
    public class PhusController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
