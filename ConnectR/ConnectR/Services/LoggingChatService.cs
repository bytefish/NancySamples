// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using log4net;
using System.Reflection;

namespace ConnectR.Services
{
    /// <summary>
    /// Logging based implementation of a <see cref="IChatService"/>.
    /// </summary>
    public class LoggingChatService : IChatService
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public void AddMessage(string name, string message)
        {
            if(log.IsInfoEnabled)
            {
                log.InfoFormat("Message added. Name = {0}, Message = {1}", name, message);
            }
        }
    }
}
