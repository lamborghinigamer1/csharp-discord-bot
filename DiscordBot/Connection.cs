using System.Net.WebSockets;
using System.Text;

namespace DiscordBot;

public class Connection(DiscordConfig discordConfig) // Using primary constructor
{
    private const string GatewayUrl = "wss://gateway.discord.gg/?v=10&encoding=json";

    private DiscordConfig _discordConfig { get; } = discordConfig; // Get the token and guild id

    private readonly ClientWebSocket socket = new(); // Create a new websocket

    public async Task ConnectAsync()
    {
        try
        {
            await socket.ConnectAsync(new Uri($"{GatewayUrl}&token={_discordConfig.Token}"), CancellationToken.None);

            var buffer = new byte[1024];
            var receiveResult = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

            while (socket.State == WebSocketState.Open)
            {
                if (receiveResult.MessageType == WebSocketMessageType.Text)
                {
                    string response = Encoding.UTF8.GetString(buffer, 0, receiveResult.Count);
                    Console.WriteLine(response);
                }
            }
        }

        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private async Task SendIdentificationAsync()
    {
        await socket.SendAsync(new ArraySegment<byte>(), WebSocketMessageType.Text, true, CancellationToken.None);
    }
}