namespace DiscordBot;

public struct DiscordConfig
{
    public required string Token { set; get; } 

    public required ulong GuildId { set; get; }

}