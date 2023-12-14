using Microsoft.AspNetCore.Mvc;
using MVCHomework.Models;
using System.Diagnostics;
using MVCHomework.Data;

namespace MVCHomework.Controllers
{
    public class HomeController : Controller
    {
        private readonly Context _context;

        public HomeController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Products.ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}