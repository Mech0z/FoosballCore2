using System.Collections.Generic;
using Models;

namespace Repository
{
    public interface IMatchupResultRepository
    {
        void SaveMatchupResult(MatchupResult matchupResult);
        List<MatchupResult> GetByHashResult(int hashcode);
    }
}