// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using NPoco;

namespace RestSample.Server.Infrastructure.Database
{
    public interface IDatabaseFactory
    {
        IDatabase GetDatabase();
    }
}