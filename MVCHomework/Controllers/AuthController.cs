using Microsoft.AspNetCore.Mvc;
using MVCHomework.Data;
using MVCHomework.Models;
using MVCHomework.Utils;

namespace MVCHomework.Controllers
{
    public class AuthController : Controller
    {
        private readonly Context _context;

        public AuthController(Context context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            PasswordHasher.HashPassword(password, out byte[] passwordHash, out byte[] passwordSalt);
            bool isUserExist = _context.Users.Any(user =>
                user.Email == email && user.PasswordHash == passwordHash && user.PasswordSalt == passwordSalt);

            if (isUserExist)
            {
                int userId = _context.Users.Single(u => u.Email == email).Id;
                var userRoles = _context.UserRoles.Where(ur => ur.UserId == userId).ToList();

                HttpContext.Session.SetString("User", email);
                HttpContext.Session.SetString("Roles", string.Join(",", userRoles));

                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(string email, string password)
        {
            bool isUserExist = _context.Users.Any(user => user.Email == email);

            if (isUserExist)
            {
                return View();
            }

            PasswordHasher.HashPassword(password, out byte[] passwordHash, out byte[] passwordSalt);
            await _context.Users.AddAsync(new User()
            {
                Email = email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            });
            await _context.SaveChangesAsync();

            int roleId = _context.Roles.Single(r => r.Name == "User").Id;
            int userId = _context.Users.Single(u => u.Email == email).Id;

            await _context.UserRoles.AddAsync(new UserRole()
            {
                UserId = userId,
                RoleId = roleId
            });
            await _context.SaveChangesAsync();

            var userRoles = _context.UserRoles.Where(ur => ur.UserId == userId).ToList();
            HttpContext.Session.SetString("User", email);
            HttpContext.Session.SetString("Roles", string.Join(",", userRoles));

            return RedirectToAction("Index", "Home");
        }
    }
}
