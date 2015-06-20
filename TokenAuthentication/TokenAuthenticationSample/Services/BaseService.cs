// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using RestSample.Server.Infrastructure.Database;

namespace RestSample.Server.Services
{
    public abstract class BaseService 
    {
        protected readonly IDatabaseFactory DatabaseFactory;

        protected BaseService(IDatabaseFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
        }
    }
}