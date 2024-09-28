using Microsoft.AspNetCore.Mvc;

namespace GracefullFloristAPI.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
