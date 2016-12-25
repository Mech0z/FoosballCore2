using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using Raven.Client;
using Raven.Client.Linq;

namespace Repository
{
    public class MatchRepository : BaseRepository<Match>, IMatchRepository
    {
        private readonly IDocumentStore _documentStore;

        public MatchRepository(IDocumentStore documentStore) : base(documentStore, "MatchesV3")
        {
            _documentStore = documentStore;
        }

        public void SaveMatch(Match match)
        {
            using (IDocumentSession session = _documentStore.OpenSession())
            {
                session.Store(match);
            }
        }

        public List<Match> GetMatches(string season)
        {
            List<Match> result;
            using (IDocumentSession session = _documentStore.OpenSession())
            {
                if (season == null)
                {
                    return session.Query<Match>("BySeason").ToList();
                }
                
                return session.Query<Match>("BySeason")
                        .Where(x => x.SeasonName == season).ToList();
            }
    }

        public Match GetByTimeStamp(DateTime time)
        {
            using (IDocumentSession session = _documentStore.OpenSession())
            {
                return session.Query<Match>("ByTime")
                                        .FirstOrDefault(m => m.TimeStampUtc == time);
            }
        }

        public IEnumerable<Match> GetMatchesByTimeStamp(DateTime time)
        {
            using (IDocumentSession session = _documentStore.OpenSession())
            {
                return session.Query<Match>("ByTime")
                                        .Where(m => m.TimeStampUtc >= time);
            }
        }

        public List<Match> GetRecentMatches(int numberOfMatches)
        {
            using (IDocumentSession session = _documentStore.OpenSession())
            {
                return session.Query<Match>("BySeason").OrderByDescending(x => x.TimeStampUtc).Take(numberOfMatches).ToList();
            }
        }

        public List<Match> GetPlayerMatches(string email)
        {
            using (IDocumentSession session = _documentStore.OpenSession())
            {
                return session.Query<Match>("ByPlayerlist").Where(x => x.PlayerList.Contains(email)).ToList();
            }
        }
    }
}