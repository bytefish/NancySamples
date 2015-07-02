// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace ConnectR.Infrastructure.Database.Entities
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