using Microsoft.AspNetCore.Mvc;

namespace ComedorMariscos.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
