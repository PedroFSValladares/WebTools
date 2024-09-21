using Microsoft.AspNetCore.SignalR;

namespace WebTools.Hubs {
    public class DiscordManagementHub : Hub{
        public async Task GetBotStatus() {
            string? botStatus = Environment.GetEnvironmentVariable("DiscordBotStatus");
            botStatus ??= "Offline";
            await Clients.All.SendAsync("ReceiveBotStatus", botStatus);
        }
    }
}
