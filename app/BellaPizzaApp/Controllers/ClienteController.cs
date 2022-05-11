using Microsoft.AspNetCore.Mvc;

namespace BellaPizzaApp.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
