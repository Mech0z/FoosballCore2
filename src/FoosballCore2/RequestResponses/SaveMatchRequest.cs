using System.Collections.Generic;
using AspNetCore.Identity.MongoDB;
using Models;

namespace FoosballCore2.RequestResponses
{
    public class SaveMatchesRequest
    {
        public MongoIdentityUser User { get; set; }
        public List<Match> Matches { get; set; }
    }
}