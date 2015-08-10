// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using ConnectR.Infrastructure.Database;

namespace ConnectR.Services
{
    /// <summary>
    /// The BaseService provides access to the <see cref="IDatabaseFactory"/>.
    /// </summary>
    public abstract class BaseService 
    {
        protected readonly IDatabaseFactory DatabaseFactory;

        protected BaseService(IDatabaseFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
        }
    }
}