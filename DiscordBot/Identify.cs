using System.Text.Json.Serialization;

namespace DiscordBot;

/// <summary>
/// The json identify object required to send to Discord
/// </summary>
internal struct Identify
{
    [JsonPropertyName("op")]
    public int Op { set; get; }

    [JsonPropertyName("d")]
    public D D { set; get; }
}