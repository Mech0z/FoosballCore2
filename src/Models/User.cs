using AspNetCore.Identity.MongoDB;

namespace Models
{
    public class User : MongoIdentityUser
    {
        public User(string userName, string email) : base(userName, email)
        {
        }

        public string LowerEmail => Email.NormalizedValue.ToLower();


        public string GravatarEmail { get; set; }
    }
}