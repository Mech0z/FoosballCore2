using System.Collections.Generic;
using Models;

namespace Repository
{
    public interface IUserRepository
    {
        List<User> GetUsers();
        void AddUser(User user);
    }
}