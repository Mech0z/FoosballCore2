using Models;

namespace Logic
{
    public interface IAchievementsService : ILogic
    {
        AchievementsView GetAchievementsView(string season);
    }
}