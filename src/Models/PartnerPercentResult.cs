using System;

namespace Models
{
    public class PartnerPercentResult : IKey
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public double? UsersNormalWinrate { get; set; }
        public int Matches { get; set; }
        public int Wins { get; set; }
    }
}
