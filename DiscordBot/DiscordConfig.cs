namespace DiscordBot;

public struct DiscordConfig
{
    public required string Token { set; get; } 
    /// <summary>
    /// The token of the bot
    /// </summary>

    public required ulong GuildId { set; get; }

}