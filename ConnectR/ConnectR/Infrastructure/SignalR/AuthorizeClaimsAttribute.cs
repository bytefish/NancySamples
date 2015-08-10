using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ConnectR.Infrastructure.Authentication
{
    /// <summary>
    /// Implements a Custom <see cref="AuthorizeAttribute"/>, so that Claims can be passed as 
    /// parameters instead of a comma separated list. 
    /// 
    /// TODO Think about overriding the other virtual methods.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class AuthorizeClaimsAttribute : AuthorizeAttribute
    {
        private string[] claims;

        public AuthorizeClaimsAttribute(params string[] claims)
        {
            this.claims = claims;
        }

        protected override bool UserAuthorized(System.Security.Principal.IPrincipal user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            var principal = user as ClaimsPrincipal;

            if (principal != null)
            {
                foreach (var claim in claims)
                {
                    if (principal.HasClaim(claim))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}