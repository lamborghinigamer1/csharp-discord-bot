namespace DiscordBot;

public struct Credentials()
{
    public string Token { set; get; } // The token of the bot

    public ulong GuildId { set; get; } // Positive long for the Discord server
}