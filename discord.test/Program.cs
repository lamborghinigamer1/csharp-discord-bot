using DiscordBot;

namespace DiscordTest;
class Program
{
    static async Task Main(string[] args)
    {
        var configReader = new ConfigReader();

        var config = configReader.ParseConfig();

        var messages = new Messages(config.Token, config.GuildId);

        await messages.ConnectAsync();

        messages.SendMessage("Hoi");
    }
}