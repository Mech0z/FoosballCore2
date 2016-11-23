using System.Collections.Generic;
using Models;

namespace Logic
{
    public interface ILeaderboardService : ILogic
    {
        LeaderboardView RecalculateLeaderboard(string season);
        LeaderboardView GetActiveLeaderboard();
        LeaderboardView GetLeaderboardView(string seasonName);
        List<LeaderboardView> GetLatestLeaderboardViews();
        void AddMatchToLeaderboard(LeaderboardView leaderboardView, Match match);
    }
}