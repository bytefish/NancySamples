using ConnectR.Services;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;

namespace ConnectR.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IChatService chatService;

        public ChatHub(IChatService chatService)
        {
            if (chatService == null)
            {
                throw new ArgumentNullException("chatService");
            }
            this.chatService = chatService;
        }

        public void Send(string name, string message)
        {
            chatService.AddMessage(name, message);

            Clients.All.addMessage(name, message);
        }
    }
}
