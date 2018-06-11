namespace SignalRWebApp
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.SignalR;

    public class SimpleHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("welcome", new object[] { new HubMessage(), new HubMessage(), new HubMessage() });

            await base.OnConnectedAsync();
        }
    }
}