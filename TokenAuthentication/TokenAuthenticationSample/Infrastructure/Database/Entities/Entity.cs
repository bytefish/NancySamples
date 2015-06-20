using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestSample.Server.Infrastructure.Database.Entities
{
    public abstract class Entity
    {
        public int Id { get; set; }

        public override string ToString()
        {
            return string.Format("Entity (Id: {0})", Id);
        }
    }
}