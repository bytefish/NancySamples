using NPoco;
using RestSample.Server.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestSample.Server.Services
{
    public class ClaimDao : BaseDao<Claim>, IClaimDao
    {
        public ClaimDao(IDatabase database)
            : base(database) { }

        public IList<Claim> GetClaims(User user)
        {
            IList<Claim> claims = Database.Fetch<Claim>(@"
                                select auth.claim.*
                                from auth.user u 
                                    inner join auth.user_claim uc on u.user_id = uc.user_id
                                    inner join auth.claim c on uc.claim_id = c.claim_id
                                where u.user_id = @0", user.Id);

            return claims;
        }
    }
}