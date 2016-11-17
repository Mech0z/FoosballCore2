using Logic;
using Microsoft.AspNetCore.Mvc;

namespace FoosballCore2.Controllers
{
    public class LeaderboardController : Controller
    {
        private readonly ILeaderboardService _leaderboardService;

        public LeaderboardController(ILeaderboardService leaderboardService)
        {
            _leaderboardService = leaderboardService;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            return View(_leaderboardService.GetLatestLeaderboardViews());
        }
    }
}
