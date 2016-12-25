using System.Collections.Generic;
using Models;

namespace Repository
{
    public interface ISeasonRepository
    {
        List<Season> GetSeasons();
        Season GetSeason(string seasonName);
        void CreateNewSeason(Season season);
        void EndSeason(Season season);
    }
}