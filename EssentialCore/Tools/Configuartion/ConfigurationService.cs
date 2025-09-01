using Microsoft.Extensions.Configuration;

namespace EssentialCore.Tools.Configuartion;

public class ConfigurationService
{
    public static IConfiguration? Configuration { get; set; }

    public static T? ReadSection<T>(string sectionName)
    {
        //Configuration.GetSection().Get<T>()

        return Configuration!.GetSection(sectionName).Get<T>();
    }

    public static string ReadValue(string key)
    {
        return Configuration[key];
    }
}

