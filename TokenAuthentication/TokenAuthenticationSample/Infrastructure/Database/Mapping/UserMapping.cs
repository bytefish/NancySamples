using NPoco.FluentMappings;
using RestSample.Server.Infrastructure.Database.Entities;

namespace RestSample.Server.Infrastructure.Database.Mapping
{
    public class UserMapping : Map<User>
    {
        public UserMapping()
        {
            PrimaryKey(p => p.Id, autoIncrement: true)
                .TableName("auth.user")
                .Columns(x =>
                {
                    x.Column(p => p.Id).WithName("user_id");
                    x.Column(p => p.Name).WithName("name");
                    x.Column(p => p.PasswordHash).WithName("password_hash");
                    x.Column(p => p.PasswordSalt).WithName("password_salt");
                });
        }
    }
}