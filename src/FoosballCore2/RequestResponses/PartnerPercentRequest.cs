using AspNetCore.Identity.MongoDB;

namespace FoosballCore2.RequestResponses
{
    public class PartnerPercentRequest
    {
        public MongoIdentityUser User { get; set; }
    }
}