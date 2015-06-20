using NPoco.FluentMappings;
using RestSample.Server.Infrastructure.Database.Entities;

namespace RestSample.Server.Infrastructure.Database.Mapping
{
    public class UserClaimsMapping : Map<UserClaims>
    {
        public UserClaimsMapping()
        {
            PrimaryKey(p => p.Id, autoIncrement: true)
                .TableName("auth.user_claim")
                .Columns(x =>
                {
                    x.Column(p => p.Id).WithName("user_claim_id");
                    x.Column(p => p.UserId).WithName("user_id");
                    x.Column(p => p.ClaimId).WithName("claim_id");
                });
        }
    }
}