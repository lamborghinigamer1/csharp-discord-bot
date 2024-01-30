namespace DiscordBot;

public class Messages : Connection
{


    public void SendMessage(string message)
    {
        Console.WriteLine($"Sent message: {message} in channel {ChannelName}");
    }
}
