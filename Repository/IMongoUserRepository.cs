using System.Collections.Generic;
using AspNetCore.Identity.MongoDB;

namespace Repository
{
    public interface IMongoUserRepository
    {
        List<MongoIdentityUser> GetUsers();
        MongoIdentityUser GetUser(string email);
    }
}