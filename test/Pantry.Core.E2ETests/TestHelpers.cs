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
                .AddEnvironmentVariables()
                .AddJsonFile("appsettings.test.json", true)
                .Build();

            var settings = config.GetSection("Pantry").Get<PantryTestSettings>() ?? new PantryTestSettings();

            if (string.IsNullOrWhiteSpace(settings.Id))
                settings.Id = Environment.GetEnvironmentVariable("PANTRY__ID");

            if (string.IsNullOrWhiteSpace(settings.Name))
                settings.Name = Environment.GetEnvironmentVariable("PANTRY__NAME");

            if (string.IsNullOrWhiteSpace(settings.Description))
                settings.Description = Environment.GetEnvironmentVariable("PANTRY__DESC");

            return settings;
        }
    }
}
