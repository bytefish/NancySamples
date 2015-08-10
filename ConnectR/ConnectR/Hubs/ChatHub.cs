using ConnectR.Infrastructure.Authentication;
using ConnectR.Services;
using log4net;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace ConnectR.Hubs
{
    [AuthorizeClaims(ConnectRClaimTypes.Admin)]
    public class ChatHub : Hub
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        
        private readonly IChatService chatService;

        public ChatHub(IChatService chatService)
        {
            if (chatService == null)
            {
                throw new ArgumentNullException("chatService");
            }
            this.chatService = chatService;
        }

        public override Task OnConnected()
        {
            if (log.IsDebugEnabled)
            {
                log.DebugFormat("OnConnected (ConnectionId = {0})", Context.ConnectionId);
            }
            return base.OnConnected();
        }

        public override Task OnReconnected()
        {
            if (log.IsDebugEnabled)
            {
                log.DebugFormat("OnReconnected (ConnectionId = {0})", Context.ConnectionId);
            }
            return base.OnReconnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            if(log.IsDebugEnabled)
            {
                log.DebugFormat("OnDisconnected (ConnectionId = {0}, StopCalled = {1})", Context.ConnectionId, stopCalled);
            }
            return base.OnDisconnected(stopCalled);
        }

        public void Send(string name, string message)
        {
            chatService.AddMessage(name, message);

            Clients.All.addMessage(name, message);
        }
    }
}
