// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace ConnectR.Infrastructure.Database.Entities
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