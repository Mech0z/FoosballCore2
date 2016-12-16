using Microsoft.AspNetCore.Mvc;
using Models;
using Repository;

namespace FoosballCore2.Controllers
{
    public class UserAdministrationController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IMatchRepository _matchRepository;

        public UserAdministrationController(IUserRepository userRepository, IMatchRepository matchRepository)
        {
            _userRepository = userRepository;
            _matchRepository = matchRepository;
        }
        public IActionResult Index()
        {
            var users = _userRepository.GetUsers();
            return View(users);
        }

        public IActionResult ChangeEmail(string oldEmail, string newEmail)
        {
            var matches = _matchRepository.GetPlayerMatches(oldEmail);

            foreach (Match match in matches)
            {
                var index = match.PlayerList.IndexOf(oldEmail);
                match.PlayerList[index] = newEmail;
                _matchRepository.SaveMatch(match);
                //send update message
            }

            return View();
        }

        public IActionResult ChangeMailOfUser()
        {
            return View();
        }
    }
}
