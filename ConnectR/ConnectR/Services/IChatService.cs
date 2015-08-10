// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace ConnectR.Services
{
    /// <summary>
    /// Sample Service used by the ChatHub.
    /// </summary>
    public interface IChatService
    {
        void AddMessage(string name, string message);
    }
}
