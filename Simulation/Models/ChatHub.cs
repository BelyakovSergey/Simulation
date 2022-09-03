using Microsoft.AspNetCore.SignalR;

namespace Simulation.Models
{
    public class ChatHub : Hub
    {
        public async Task Send(string message)
        {
            await this.Clients.Caller.SendAsync("Send", message);
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("Notify", $"{Context.ConnectionId} вошел в чат");
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Clients.All.SendAsync("Notify", $"{Context.ConnectionId} покинул чат");
            await base.OnDisconnectedAsync(exception);
        }
    }
}
