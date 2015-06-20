using NPoco;
using RestSample.Server.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestSample.Server.Services
{
    public class UserDao : BaseDao<User>, IUserDao
    {
        public UserDao(IDatabase database)
            : base(database) { }

        public User GetByName(string name)
        {
            return Database.Query<User>().FirstOrDefault(x => x.Name == name);
        }
    }
}