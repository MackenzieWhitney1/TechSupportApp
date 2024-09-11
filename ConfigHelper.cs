using System;

using Microsoft.Extensions.Configuration;
using System;
using System.IO;

public class ConfigHelper
{
    public static IConfigurationRoot Configuration { get; private set; }

    static ConfigHelper()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        Configuration = builder.Build();
    }

    public static string GetConnectionString(string name)
    {
        return Configuration.GetConnectionString(name);
    }
}
