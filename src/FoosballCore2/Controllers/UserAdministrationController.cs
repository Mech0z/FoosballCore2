using System.Collections.Generic;
using System.Linq;
using AspNetCore.Identity.MongoDB;
using FoosballCore2.ViewModels;
using Logic;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repository;

namespace FoosballCore2.Controllers
{
    public class UserAdministrationController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IMatchRepository _matchRepository;
        private readonly IUserLogic _userLogic;

        public UserAdministrationController(IUserRepository userRepository, IMatchRepository matchRepository, IUserLogic userLogic)
        {
            _userRepository = userRepository;
            _matchRepository = matchRepository;
            _userLogic = userLogic;
        }
        public IActionResult Index()
        {
            var users = _userLogic.GetCombinedUsers();

            return View(users);
        }

        public IActionResult GetAllMatchUsers()
        {
            List<User> users = _userRepository.GetUsers();

            List<string> emails = _matchRepository.GetUniqueEmails();

            var result = new List<string>();
            
            foreach (string email in emails)
            {
                if (users.All(x => x.Email.ToLower() != email.ToLower()))
                {
                    result.Add(email);
                }
            }

            return View("ChangeEmailView", new ChangeEmailViewModel
            {
                RegisteredUsers = users,
                EmailsWithoutUsers = result
            });
        }
        
        public IActionResult ChangeEmail(string oldEmail, string newEmail)
        {
            var matches = _matchRepository.GetPlayerMatches(oldEmail);

            foreach (Match match in matches)
            {
                var index = match.PlayerList.IndexOf(oldEmail);
                match.PlayerList[index] = newEmail;
                _matchRepository.Upsert(match);
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
