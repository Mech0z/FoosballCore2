using System.Collections.Generic;
using Microsoft.Extensions.Options;
using Models;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(IOptions<MongoDbSettings> settings) : base(settings, "Users")
        {
        }

        public List<User> GetUsers()
        {
            var query = Collection.AsQueryable();
            
            return query.ToList();
        }

        public void AddUser(User user)
        {
            Collection.InsertOne(user);
        }

        public User GetUser(string email)
        {
            var user = Collection.AsQueryable().Where(x => x.Email == email).FirstOrDefault();
            return user;
        }
    }
}