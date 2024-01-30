namespace DiscordBot;

public struct Credentials()
{
    public required string Token { set; get; } // The token of the bot

    public required ulong GuildId { set; get; } // Positive long for the Discord server
}