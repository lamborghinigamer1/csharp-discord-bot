using DiscordBot;

namespace DiscordTest;

public struct Config
{
    public required DiscordConfig DiscordConfig { get; set; }
    /// <summary>
    /// The config data with token and guildid
    /// </summary>

    public required Settings Settings { get; set; }
}