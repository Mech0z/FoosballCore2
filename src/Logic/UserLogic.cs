using System.Collections.Generic;
using System.Linq;
using AspNetCore.Identity.MongoDB;
using Models;
using Repository;

namespace Logic
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserRepository _userRepository;
        private readonly IMongoUserRepository _mongoUserRepository;

        public UserLogic(IUserRepository userRepository, IMongoUserRepository mongoUserRepository)
        {
            _userRepository = userRepository;
            _mongoUserRepository = mongoUserRepository;
        }

        public CombinedUser GetCombinedUser(string email)
        {
            var user = _userRepository.GetUser(email);
            var mongoUser = _mongoUserRepository.GetUser(email);

            return new CombinedUser
            {
                User = user,
                MongoIdentityUser = mongoUser
            };
        }

        public List<CombinedUser> GetCombinedUsers()
        {
            var users = _userRepository.GetUsers();
            var mongoUsers = _mongoUserRepository.GetUsers();

            var result = new List<CombinedUser>();

            foreach (User user in users)
            {
                result.Add(new CombinedUser
                {
                    Email = user.Email.ToLower(),
                    User = user,
                    MongoIdentityUser = mongoUsers.SingleOrDefault(x => x.Email.NormalizedValue.ToLower() == user.Email.ToLower())
                });
            }

            foreach (MongoIdentityUser user in mongoUsers)
            {
                if (result.All(x => x.Email.ToLower() != user.Email.NormalizedValue.ToLower()))
                {
                    result.Add(new CombinedUser
                    {
                        Email = user.Email.NormalizedValue.ToLower(),
                        MongoIdentityUser = user
                    });
                }
            }

            return result;
        }
    }
}