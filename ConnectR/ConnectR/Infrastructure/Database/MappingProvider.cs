// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using NPoco.FluentMappings;
using ConnectR.Infrastructure.Database.Mapping;

namespace ConnectR.Infrastructure.Database
{
    /// <summary>
    /// Simply fixed for this sample. Should be moved to a separate module.
    /// </summary>
    public class MappingProvider : IMappingProvider
    {
        public IMap[] GetMappings()
        {
            return new IMap[] { new UserMapping(), new ClaimMapping(), new UserClaimsMapping() };
        }
    }
}