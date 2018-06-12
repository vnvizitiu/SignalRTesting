namespace SignalRWebApp
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.SignalR;

    public class SimpleHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            await Welcome();

            await base.OnConnectedAsync();
        }

        public async Task Welcome()
        {
            await Clients.All.SendAsync("welcome", new[] { new HubMessage(), new HubMessage(), new HubMessage() });
        }
    }
}