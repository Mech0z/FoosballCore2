using System.Collections.Generic;
using System.Linq;
using Models;
using Raven.Client;

namespace Repository
{
    public class LeaderboardViewRepository : BaseRepository<LeaderboardView>, ILeaderboardViewRepository
    {
        private readonly IDocumentStore _documentStore;

        public LeaderboardViewRepository(IDocumentStore documentStore) : base(documentStore, "LeaderboardViews")
        {
            _documentStore = documentStore;
        }

        public LeaderboardView GetLeaderboardView(string seasonName)
        {
            using (IDocumentSession session = _documentStore.OpenSession())
            {
                return session.Query<LeaderboardView>("ByTime")
                    .FirstOrDefault(m => m.SeasonName == seasonName);
            }
        }

        public List<LeaderboardView> GetLeaderboardViews()
        {
            using (IDocumentSession session = _documentStore.OpenSession())
            {
                return session.Query<LeaderboardView>("ByTime")
                                                        .OrderBy(m => m.Timestamp).ToList();
            }
        }

        public void SaveLeaderboardView(LeaderboardView view)
        {
            using (IDocumentSession session = _documentStore.OpenSession())
            {
                session.Store(view);
            }
        }
    }
}