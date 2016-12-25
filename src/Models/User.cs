using RavenDB.AspNetCore.Identity.Entities;

namespace Models
{
    public class User : RavenUser
    {
        public string Name { get; set; }

        public string GravatarEmail { get; set; }

        public string Password { get; set; }
    }
}
