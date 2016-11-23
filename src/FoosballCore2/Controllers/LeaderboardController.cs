using System.Collections.Generic;
using Logic;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace FoosballCore2.Controllers
{
    public class LeaderboardController : Controller
    {
        private readonly ILeaderboardService _leaderboardService;
        private readonly ISeasonLogic _seasonLogic;

        public LeaderboardController(ILeaderboardService leaderboardService, ISeasonLogic seasonLogic)
        {
            _leaderboardService = leaderboardService;
            _seasonLogic = seasonLogic;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Season> seasons = _seasonLogic.GetSeasons();

            return View(seasons);
        }

        [HttpGet]
        public IActionResult ActiveSeasonView()
        {
            var activeSeason = _seasonLogic.GetActiveSeason();
            return (RedirectToAction("SeasonView", new { seasonName = activeSeason.Name }));
        }

        public IActionResult SeasonView(string seasonName)
        {
            var leaderboard = _leaderboardService.GetLeaderboardView(seasonName);

            return View(leaderboard);
        }
    }
}
