using System.Text.Json;

namespace DiscordTest;

/// <summary>
/// Class responsible for reading and parsing configuration from a JSON file.
/// </summary>
/// <param name="configFile"></param>
public class ConfigReader(string configFile)
{
    private readonly string _configFile = configFile;

    /// <summary>
    /// Parses the configuration from the specified JSON file.
    /// </summary>
    /// <returns>The parsed settings and token configuration.</returns>
    public Config ParseConfig()
    {
        try
        {
            var configjson = File.ReadAllText(_configFile);
            var parsedconfig = JsonSerializer.Deserialize<Config>(configjson);
            return parsedconfig;
        }
        catch (JsonException err)
        {
            Console.WriteLine(err);
            throw;
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
}