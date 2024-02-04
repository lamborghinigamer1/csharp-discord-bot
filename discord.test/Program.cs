using DiscordBot;

namespace DiscordTest;
class Program
{
    static async Task Main(string[] args)
    {
        var configReader = new ConfigReader("config.json");

        var config = configReader.ParseConfig();

        var messages = new Messages(config.DiscordConfig);

        await messages.ConnectAsync();

        messages.SendMessage("Hoi");
    }
}