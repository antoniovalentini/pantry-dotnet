using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace Pantry.Core.E2ETests
{
    public static class TestHelpers
    {
        public static PantryTestSettings GetTestSettings()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                .AddJsonFile("appsettings.test.json", true)
                .AddEnvironmentVariables()
                .Build();

            var settings = config.GetSection("Pantry").Get<PantryTestSettings>() ?? new PantryTestSettings();

            if (string.IsNullOrWhiteSpace(settings.Id))
                throw new ArgumentException(nameof(settings.Id));

            if (string.IsNullOrWhiteSpace(settings.Name))
                throw new ArgumentException(nameof(settings.Name));

            if (string.IsNullOrWhiteSpace(settings.Description))
                throw new ArgumentException(nameof(settings.Description));

            Console.WriteLine(settings.Id);
            return settings;
        }
    }
}
