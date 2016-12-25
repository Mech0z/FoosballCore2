using System.Collections.Generic;
using System.Linq;
using Models;
using Raven.Client;
using Raven.Client.Linq;

namespace Repository
{
    public class MatchupResultRepository : BaseRepository<MatchupResult>, IMatchupResultRepository
    {
        private readonly IDocumentStore _documentStore;

        public MatchupResultRepository(IDocumentStore documentStore) : base(documentStore, "MatchupResults")
        {
            _documentStore = documentStore;
        }

        public void SaveMatchupResult(MatchupResult matchupResult)
        {
            using (IDocumentSession session = _documentStore.OpenSession())
            {
                session.Store(matchupResult);
            }
        }

        public List<MatchupResult> GetByHashResult(int hashcode)
        {
            using (IDocumentSession session = _documentStore.OpenSession())
            {
                return session.Query<MatchupResult>("ByHashcode").Where(x => x.HashResult == hashcode).ToList();
            }
        }
    }
}