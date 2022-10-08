using Microsoft.AspNetCore.SignalR;

namespace BlazorServer.Hubs;

public class ChatHub : Hub
{
    public Task SendMessage(string user, string message, DateTime messageDateTime)
    {
        return Clients.All.SendAsync("ReceiveMessage", user, message, messageDateTime);
    }
}

