using System.Collections.Generic;
using System.Linq;
using AspNetCore.Identity.MongoDB;
using Logic;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repository;

namespace FoosballCore2.Controllers
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
            return View(_userRepository.GetUser(email));
        }
    }
}