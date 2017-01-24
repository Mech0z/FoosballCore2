using System;

namespace Models
{
    public class User : IKey
    {
        public Guid Id { get; set; }
        
        public string Email { get; set; }

        public string Username { get; set; }

        public string GravatarEmail { get; set; }

        public string Password { get; set; }
    }
}