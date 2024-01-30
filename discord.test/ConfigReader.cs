using System.Text.Json;

namespace DiscordTest;

public class ConfigReader
{

    private const string ConfigFilePath = "config.json";

    private bool ConfigExists()
    {
        try
        {
            File.OpenRead(ConfigFilePath);
            return true;
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"config.json is missing");
            throw;
        }
        catch (IOException)
        {
            Console.WriteLine($"Error accessing config.json");
            throw;
        }
    }

    public Credentials ParseConfig()
    {
        try
        {
            ConfigExists();
            var configjson = File.OpenRead(ConfigFilePath);
            var parsedconfig = JsonSerializer.Deserialize<Credentials>(configjson);
            return parsedconfig;

        }
        catch (JsonException err)
        {
            Console.WriteLine(err);
            throw;
        }
    }
}