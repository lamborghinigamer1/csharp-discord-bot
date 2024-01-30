namespace DiscordBot;

public class Messages(Credentials credentials) : Connection(credentials)
{
    public void SendMessage(string message)
    {
        Console.WriteLine($"Sent message: {message} in channel");
    }
}
