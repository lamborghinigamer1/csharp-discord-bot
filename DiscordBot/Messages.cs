namespace DiscordBot;

public class Messages(DiscordConfig discordConfig) : Connection(discordConfig)
{
    public void SendMessage(string message)
    {
        Console.WriteLine($"Sent message: {message} in channel");
    }
}
