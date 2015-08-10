// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using ConnectR.Hubs;
using log4net;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Infrastructure;
using System.Reflection;

namespace ConnectR.Services
{
    public class UploadNotificationService : IUploadNotificationService
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IConnectionManager connectionManager;

        public UploadNotificationService(IConnectionManager connectionManager)
        {
            this.connectionManager = connectionManager;
        }

        public void OnFileUploaded(string fileName)
        {
            if (log.IsInfoEnabled)
            {
                log.InfoFormat("A file has been uploaded. Name = {0}.", fileName);
            }

            HubContext.Clients.All.addMessage("[System]", string.Format("File {0} has been uploaded", fileName));
        }

        private IHubContext _hubContext;
        private IHubContext HubContext
        {
            get
            {
                if (_hubContext == null)
                {
                    _hubContext = connectionManager.GetHubContext<ChatHub>();
                }

                return _hubContext;
            }
        }
    }
}
