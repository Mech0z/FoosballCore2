using AspNetCore.Identity.MongoDB;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FoosballCore2.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<MongoIdentityUser> _userManager;
        private readonly SignInManager<MongoIdentityUser> _signInManager;

        public HomeController(UserManager<MongoIdentityUser> userManager,
            SignInManager<MongoIdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult Setup()
        {
            var users = _userManager.Users;
            //var users = _userManager.GetUsersForClaimAsync("Admin").Result;

            //if (users.Count == 0)
            //{
            //    var user = _signInManager.GetTwoFactorAuthenticationUserAsync().Result;
            //    var result = _userManager.AddToRoleAsync(user, "Admin").Result;
            //}

            return RedirectToAction("Index");
        }
    }
}
