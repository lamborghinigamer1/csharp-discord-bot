namespace DiscordBot;

public class Messages(string token, ulong guildId) : Connection(token, guildId)
{
    public void SendMessage(string message)
    {
        Console.WriteLine($"Sent message: {message} in channel");
    }
}
