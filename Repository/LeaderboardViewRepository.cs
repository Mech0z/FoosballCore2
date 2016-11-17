﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Models;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Repository
{
    public class LeaderboardViewRepository : BaseRepository<LeaderboardView>, ILeaderboardViewRepository
    {
        public LeaderboardViewRepository(IOptions<MongoDbSettings> settings) : base(settings, "LeaderboardViews")
        {

        }

        public LeaderboardView GetLeaderboardView(string seasonName)
        {
            var query = Collection.AsQueryable();

            query.OrderBy(x => x.Timestamp);
            query.Where(x => x.SeasonName == seasonName);

            return query.Single();
        }

        public List<LeaderboardView> GetLeaderboardViews()
        {
            var query = Collection.AsQueryable();

            query.OrderBy(x => x.Timestamp);
            
            return query.ToList();
        }

        public void SaveLeaderboardView(LeaderboardView view)
        {
            Collection.InsertOne(view);
        }
    }
}