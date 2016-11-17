using System.Collections.Generic;
using Microsoft.Extensions.Options;
using Models;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Repository
{
    public class MatchupResultRepository : BaseRepository<MatchupResult>, IMatchupResultRepository
    {
        public MatchupResultRepository(IOptions<MongoDbSettings> settings) : base(settings, "MatchupResults")
        {

        }

        public void SaveMatchupResult(MatchupResult matchupResult)
        {
            Collection.InsertOne(matchupResult);
        }

        public List<MatchupResult> GetByHashResult(int hashcode)
        {
            var query = Collection.AsQueryable();

            query.Where(x => x.HashResult == hashcode);

            return query.ToList();
        }
    }
}