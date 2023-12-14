using Microsoft.AspNetCore.Mvc;

namespace MVCHomework.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
