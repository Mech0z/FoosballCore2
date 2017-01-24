using AspNetCore.Identity.MongoDB;

namespace Models
{
    public class CombinedUser
    {
        public string Email { get; set; }
        public MongoIdentityUser MongoIdentityUser { get; set; }
        public User User { get; set; }
    }
}