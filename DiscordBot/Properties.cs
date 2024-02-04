using System.Text.Json.Serialization;

namespace DiscordBot;

/// <summary>
/// The json properties object required to send to Discord
/// </summary>
internal struct Properties
{
    [JsonPropertyName("os")]
    public string Os { set; get; }

    [JsonPropertyName("browser")]
    public string Browser { set; get; }

    [JsonPropertyName("device")]
    public string Device { set; get; }
}