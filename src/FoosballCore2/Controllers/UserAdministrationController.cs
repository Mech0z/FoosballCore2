using Microsoft.AspNetCore.Mvc;
using Repository;

namespace FoosballCore2.Controllers
{
    public class UserAdministrationController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserAdministrationController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public IActionResult Index()
        {
            var users = _userRepository.GetUsers();
            return View(users);
        }

        public IActionResult ChangeMailOfUser()
        {
            return View();
        }
    }
}
