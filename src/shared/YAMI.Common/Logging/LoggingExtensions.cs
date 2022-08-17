using System.Reflection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace YAMI.Common.Logging;

public static class LoggingExtensions
{
    public static IHostBuilder UseLogging(this IHostBuilder hostBuilder)
            => hostBuilder.UseSerilog((context, loggerConfiguration) =>
            {
                var applicationName = Assembly.GetEntryAssembly()?.FullName?.Split(',')[0].ToLowerInvariant() ?? string.Empty;

                loggerConfiguration.Enrich.FromLogContext()
                    .Enrich.WithProperty("Environment", context.HostingEnvironment.EnvironmentName)
                    .Enrich.WithProperty("ApplicationName", applicationName)
                    .WriteTo.Console();
            });
}
