// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace RestSample.Server.Infrastructure.Database
{
    public class ConnectionStringSettings
    {
        public readonly string ConnectionString;
        public readonly string ProviderName;

        public ConnectionStringSettings(string connectionString, string providerName) 
        {
            ConnectionString = connectionString;
            ProviderName = providerName;
        }
    }
}