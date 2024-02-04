using System.Net.WebSockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;

namespace DiscordBot;

public class Connection(DiscordConfig discordConfig) // Using primary constructor
{
    private const string GatewayUrl = "wss://gateway.discord.gg/?v=10&encoding=json";

    private DiscordConfig DiscordConfig { get; } = discordConfig; // Get the token and guild id

    private readonly ClientWebSocket _socket = new(); // Create a new websocket

    /// <summary>
    /// Connects to Discord with async
    /// </summary>
    public async Task ConnectAsync()
    {
        try
        {
            await _socket.ConnectAsync(new Uri($"{GatewayUrl}"), CancellationToken.None);

            var buffer = new byte[1024];
            var receiveResult = await _socket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

            await SendIdentificationAsync();

            while (_socket.State == WebSocketState.Open)
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

    /// <summary>
    /// It gets the name of the operating system you're using
    /// </summary>
    /// <returns>String</returns>
    private static string GetOperatingSystem()
    {
        string os;

        switch (RuntimeInformation.OSDescription)
        {
            case var windows when windows.Contains("Windows"):
                os = "Windows";
                break;
            case var linux when linux.Contains("Linux"):
                os = "Linux";
                break;
            case var macOS when macOS.Contains("Darwin"):
                os = "macOS";
                break;
            default:
                os = "Unknown";
                break;
        }

        return os.ToLower();
    }

    /// <summary>
    /// It will send your identity including token
    /// </summary>
    private async Task SendIdentificationAsync()
    {
        var info = new Identify
        {
            Op = 2,
            D = new D()
            {
                Intents = 513,
                Token = DiscordConfig.Token,
                Properties = new Properties()
                { Os = GetOperatingSystem(), Browser = "my_library", Device = "my_library" }
            },
        };

        var infoJson = JsonSerializer.Serialize(info);

        Console.WriteLine(infoJson);

        await _socket.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes(infoJson)), WebSocketMessageType.Text, true, CancellationToken.None);
    }
}