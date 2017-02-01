using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace Repository
{
    public interface ILeaderboardViewRepository
    {
        LeaderboardView GetLeaderboardView(string seasonName);
        List<LeaderboardView> GetLeaderboardViews();
        void Upsert(LeaderboardView view);
    }
}