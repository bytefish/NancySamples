using NPoco.FluentMappings;
using RestSample.Server.Infrastructure.Database.Entities;

namespace RestSample.Server.Infrastructure.Database.Mapping
{
    public class ClaimMapping : Map<Claim>
    {
        public ClaimMapping()
        {
            PrimaryKey(p => p.Id, autoIncrement: true)
                .TableName("auth.claim")
                .Columns(x =>
                {
                    x.Column(p => p.Id).WithName("claim_id");
                    x.Column(p => p.Name).WithName("name");
                });
        }
    }
}