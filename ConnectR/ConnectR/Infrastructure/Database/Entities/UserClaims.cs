// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace ConnectR.Infrastructure.Database.Entities
{
    public class UserClaims : Entity
    {
        public string UserId { get; set; }

        public string ClaimId { get; set; }

        public string Value { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, UserClaim (UserId: {1}, ClaimId: {2})", base.ToString(), UserId, ClaimId);
        }
    }
}