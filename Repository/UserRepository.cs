using System.Collections.Generic;
using Microsoft.Extensions.Options;
using Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(IOptions<MongoDbSettings> settings) : base(settings, "users")
        {
        }

        public List<User> GetUsers()
        {
            var sdf = Collection.ToBsonDocument();
            var query = Collection.AsQueryable();
            
            return query.ToList();
        }

        public void AddUser(User user)
        {
            Collection.InsertOne(user);
        }

        public User GetUser(string email)
        {
            var user = Collection.AsQueryable().Where(x => x.Email.NormalizedValue == email).FirstOrDefault();
            return user;
        }
    }
}