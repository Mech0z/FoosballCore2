using System.Collections.Generic;
using System.Linq;
using Logic;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repository;

namespace FoosballCore.Controllers
{
    public class PlayerController : Controller
    {
        private readonly IMatchRepository _matchRepository;
        private readonly IMatchupHistoryCreator _matchupHistoryCreator;
        private readonly ISeasonLogic _seasonLogic;
        private readonly IUserRepository _userRepository;

        public PlayerController(IMatchRepository matchRepository,
            IUserRepository userRepository,
            IMatchupHistoryCreator matchupHistoryCreator,
            ISeasonLogic seasonLogic)
        {
            _matchRepository = matchRepository;
            _userRepository = userRepository;
            _matchupHistoryCreator = matchupHistoryCreator;
            _seasonLogic = seasonLogic;
        }

        [HttpGet]
        public IEnumerable<Match> GetPlayerMatches(string email)
        {
            return _matchRepository.GetPlayerMatches(email).OrderByDescending(x => x.TimeStampUtc);
        }

        [HttpGet]
        public List<PartnerPercentResult> GetPlayerPartnerResults(string email)
        {
            var activeSeason = _seasonLogic.GetActiveSeason();

            return _matchupHistoryCreator.GetPartnerWinPercent(email, activeSeason.Name);
        }

        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            return _userRepository.GetUsers();
        }

        [HttpGet]
        public ActionResult Index(string email)
        {
            User user = _userRepository.GetUser(email);

            if (user == null)
            {
                user = new User(email, email);
                _userRepository.AddUser(user);
                user = _userRepository.GetUser(email);
            }

            return View(user);
        }

        //[HttpPost]
        //public ActionResult CreateUser(User user)
        //{
        //    var users = _userRepository.GetUsers();

        //    if (users.Any(x => x.Email == user.Email))
        //        return BadRequest("Email already exists");

        //    _userRepository.AddUser(user);
        //    return Ok();
        //}
    }
}