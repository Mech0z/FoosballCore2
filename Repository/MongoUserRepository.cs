using System.Collections.Generic;
using AspNetCore.Identity.MongoDB;
using Microsoft.Extensions.Options;
using Models;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Repository
{
    public class MongoUserRepository : IMongoUserRepository
    {
        protected static IMongoClient Client;
        protected static IMongoDatabase Database;
        private readonly string _collectionName;

        public IMongoCollection<MongoIdentityUser> Collection => Database.GetCollection<MongoIdentityUser>(_collectionName);

        public MongoUserRepository(IOptions<MongoDbSettings> settings)
        {
            Client = new MongoClient(settings.Value.ConnectionString);

            Database = Client.GetDatabase(settings.Value.DatabaseName);
            _collectionName = "users";
        }
        
        public List<MongoIdentityUser> GetUsers()
        {
            var query = Collection.AsQueryable();

            return query.ToList();
        }

        public MongoIdentityUser GetUser(string email)
        {
            var user = Collection.AsQueryable().Where(x => x.Email.NormalizedValue == email).FirstOrDefault();
            return user;
        }
    }
}