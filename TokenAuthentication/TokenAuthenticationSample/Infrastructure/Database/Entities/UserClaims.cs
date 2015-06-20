using Nancy.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestSample.Server.Infrastructure.Database.Entities
{
    public class UserClaims : Entity
    {
        public string UserId { get; set; }

        public string ClaimId { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, UserClaim (UserId: {1}, ClaimId: {2})", base.ToString(), UserId, ClaimId);
        }
    }
}