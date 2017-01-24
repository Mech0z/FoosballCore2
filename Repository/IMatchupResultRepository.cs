using System.Collections.Generic;
using Models;

namespace Repository
{
    public interface IMatchupResultRepository
    {
        void Upsert(MatchupResult matchupResult);
        List<MatchupResult> GetByHashResult(int hashcode);
    }
}