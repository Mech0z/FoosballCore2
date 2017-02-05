using AspNetCore.Identity.MongoDB;
using System;

namespace Models
{
    public class User : MongoIdentityUser, IKey
    {
        public User(string userName, string email) : base(userName, email)
        {

        }

        public string LowerEmail {            get
            {
                return base.Email.NormalizedValue.ToLower();
            } }

        public  new Guid Id { get { return new Guid(base.Id); } }

        public string GravatarEmail { get; set; }
    }
}