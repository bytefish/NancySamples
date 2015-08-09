// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace ConnectR.Infrastructure.Database.Entities
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