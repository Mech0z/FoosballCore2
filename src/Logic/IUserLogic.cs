using System.Collections.Generic;
using Models;

namespace Logic
{
    public interface IUserLogic
    {
        CombinedUser GetCombinedUser(string email);
        List<CombinedUser> GetCombinedUsers();
    }
}