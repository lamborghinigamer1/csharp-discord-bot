using System.Net.WebSockets;
using System.Text;
using System.Text.Json;

namespace DiscordBot;

public class Connection(string token, ulong guildId) // Using primary constructor
{
    private const string GatewayUrl = "wss://gateway.discord.gg/?v=10&encoding=json";

    private string Token { get; } = token; // Get the token

    private ulong GuildId { get; } = guildId; // Get the guild id

    private readonly ClientWebSocket socket = new(); // Create a new websocket

    public async Task ConnectAsync()
    {
        try
        {
            await socket.ConnectAsync(new Uri($"{GatewayUrl}&token={Token}"), CancellationToken.None);

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

    private async Task SendIdenficationAsync()
    {
        var identificationPayload = new
        {
            op = 2, // Identify operation code
            d = new
            {
                token = Token,
                intents = 513, // Your bot's intent (e.g., GUILD_MESSAGES) - modify as needed
                properties = new
                {
                        $os = "windows",
                        $browser = "",
                        $device = "your-bot-name"
                }
            }
        };
        var payloadJson = JsonSerializer.Serialize(identificationPayload);
        var payloadBytes = Encoding.UTF8.GetBytes(payloadJson);

        await socket.SendAsync(new ArraySegment<byte>(payloadBytes), WebSocketMessageType.Text, true, CancellationToken.None);
    }
}