using System.Text.Json.Serialization;

namespace DiscordBot;

/// <summary>
/// The json d object required to send to Discord
/// </summary>
internal struct D
{
    [JsonPropertyName("token")]
    public string Token { set; get; }

    [JsonPropertyName("intents")]
    public int Intents { set; get; }

    [JsonPropertyName("properties")]
    public Properties Properties { set; get; }
}