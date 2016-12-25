using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Extensions.Options;
using Models;
using Raven.Client;

namespace Repository
{
    public class SeasonRepository : BaseRepository<Season>, ISeasonRepository
    {
        private readonly IDocumentStore _documentStore;

        public SeasonRepository(IDocumentStore documentStore) : base(documentStore, "Seasons")
        {
            _documentStore = documentStore;
        }

        public List<Season> GetSeasons()
        {
            using (IDocumentSession session = _documentStore.OpenSession())
            {
                return session.Load<Season>().ToList();
            }
        }

        public void CreateNewSeason(Season season)
        {
            using (IDocumentSession session = _documentStore.OpenSession())
            {
                session.Store(season);
            }
        }

        public void EndSeason(Season season)
        {
            using (IDocumentSession session = _documentStore.OpenSession())
            {
                var seasonResult = session.Query<Season>("ByName")
                                        .FirstOrDefault(m => m.Name == season.Name);

                seasonResult.EndDate = DateTime.UtcNow.Date.AddHours(23);
                
                session.Store(season);
            }
        }

        public Season GetSeason(string seasonName)
        {
            using (IDocumentSession session = _documentStore.OpenSession())
            {
                return session.Query<Season>("BySeasonName")
                                        .FirstOrDefault(m => m.Name == seasonName);
            }
        }
    }
}