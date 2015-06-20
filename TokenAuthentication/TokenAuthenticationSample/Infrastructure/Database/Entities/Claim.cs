using Nancy.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestSample.Server.Infrastructure.Database.Entities
{
    public class Claim : Entity
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, Claim (Name: {1}", base.ToString(), Name);
        }
    }
}