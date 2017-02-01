using System.Collections.Generic;
using Models;

namespace FoosballCore2.ViewModels
{
    public class ChangeEmailViewModel
    {
        public List<User> RegisteredUsers { get; set; }
        public List<string> EmailsWithoutUsers { get; set; }
    }
}