using DiscordBot;

class Program
{
    static void Main(string[] args)
    {
        var messages = new Messages
        {
            ChannelName = "hoi"
        };

        messages.SendMessage("Hello");
    }
}