using System.Collections.Generic;
using Models;

namespace Repository
{
    public interface IUserRepository
    {
        List<User> GetUsers();
        User GetUser(string email);
        void AddUser(User user);
    }
}