using Nancy.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestSample.Server.Infrastructure.Database.Entities
{
    public class User : Entity
    {
        public string Name { get; set; }

        public string PasswordHash { get; set; }

        public string PasswordSalt { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, User (Name: {1}, PasswordHash: {2}, PasswordSalt: {3})", base.ToString(), Name, PasswordHash, PasswordSalt);
        }
    }
}