using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Logic;
using System.Linq;
using Models;
using Repository;
using System;
using Foosball9000Api.RequestResponse;

namespace Foosball9000Api.Controllers
{
    public class MatchController : Controller
    {
        private readonly ILeaderboardService _leaderboardService;
        private readonly ILeaderboardViewRepository _leaderboardViewRepository;
        private readonly IUserRepository _userRepository;
        private readonly ISeasonLogic _seasonLogic;
        private readonly IMatchRepository _matchRepository;
        private readonly IMatchupResultRepository _matchupResultRepository;

        public MatchController(IMatchRepository matchRepository,
            IMatchupResultRepository matchupResultRepository,
            ILeaderboardService leaderboardService,
            ILeaderboardViewRepository leaderboardViewRepository,
            IUserRepository userRepository,
            ISeasonLogic seasonLogic)
        {
            _matchRepository = matchRepository;
            _matchupResultRepository = matchupResultRepository;
            _leaderboardService = leaderboardService;
            _leaderboardViewRepository = leaderboardViewRepository;
            _userRepository = userRepository;
            _seasonLogic = seasonLogic;
        }

        // GET: /api/Match/GetAll
        [HttpGet]
        public IEnumerable<Match> GetAll()
        {
            var matches = _matchRepository.GetMatches(null);
            return matches;        }

        // GET: /api/Match/LastGames?numberOfMatches=10
        [HttpGet]
        public IEnumerable<Match> LastGames(int numberOfMatches)
        {
            return _matchRepository.GetRecentMatches(numberOfMatches);
        }

        [HttpPost]
        public IActionResult SaveMatch(SaveMatchesRequest saveMatchesRequest)
        {
            if (saveMatchesRequest == null)
            {
                return BadRequest();
            }
            //var validated = _userRepository.Validate(saveMatchesRequest.User);
            //if (!validated)
            //{
            //    return Unauthorized();
            //}

            var seasons = _seasonLogic.GetSeasons();

            if (seasons.All(x => x.EndDate != null))
            {
                return BadRequest("No active seaons");
            }

            var currentSeason = seasons.Single(x => x.EndDate == null);

            var matches = saveMatchesRequest.Matches.OrderBy(x => x.TimeStampUtc).ToList();

            //Sat i AddMatch java
            foreach (var match in matches)
            {
                if (match.TimeStampUtc == DateTime.MinValue)
                {
                    match.TimeStampUtc = DateTime.UtcNow;
                }
                
                match.SeasonName = currentSeason.Name;

                var leaderboards = _leaderboardService.GetLatestLeaderboardViews();

                var activeLeaderboard = leaderboards.SingleOrDefault(x => x.SeasonName == currentSeason.Name);

                _leaderboardService.AddMatchToLeaderboard(activeLeaderboard, match);

                _matchRepository.SaveMatch(match);

                _leaderboardViewRepository.SaveLeaderboardView(activeLeaderboard);
            }
            
            return Ok();
        }

        [HttpGet]
        public MatchupResult GetMatchupResult(List<string> userlist)
        {
            userlist = new List<string> { "jasper@sovs.net", "maso@seges.dk", "madsskipper@gmail.com", "anjaskott@gmail.com"};

            //Sort
                var sortedUserlist = userlist.OrderBy(x => x).ToList();
            var addedList = string.Join("", sortedUserlist.ToArray());

            //RecalculateLeaderboard hashstring
            var hashcode = addedList.GetHashCode();

            //RecalculateLeaderboard the correct one
            var results = _matchupResultRepository.GetByHashResult(hashcode);

            //TODO dont seem optimal to create a list every time
            var team1list = new List<string> {userlist[0], userlist[1]};
            var team1Hashcode = team1list.OrderBy(x => x).GetHashCode();

            var team2list = new List<string> {userlist[3], userlist[4]};
            var team2Hashcode = team2list.OrderBy(x => x).GetHashCode();

            var result =
                results.Single(x =>
                    (x.Team1HashCode == team1Hashcode || x.Team1HashCode == team2Hashcode) &&
                    (x.Team2HashCode == team1Hashcode || x.Team2HashCode == team2Hashcode));

            return result;
        }

        [HttpGet]
        public IEnumerable<Match> TodaysMatches()
        {
            return _matchRepository.GetMatchesByTimeStamp(DateTime.Today);
        }
    }
}