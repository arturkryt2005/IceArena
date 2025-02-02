using Microsoft.AspNetCore.Mvc;

namespace IceArena.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
