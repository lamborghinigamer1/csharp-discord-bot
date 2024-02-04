using DiscordBot;

namespace DiscordTest;

struct Config
{
    public DiscordConfig DiscordConfig { get; set; }
    /// <summary>
    /// The config data with token and guildid
    /// </summary>

    public Settings Settings { get; set; }
}