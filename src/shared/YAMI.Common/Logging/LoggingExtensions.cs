using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace YAMI.Common.Logging;

public static class LoggingExtensions
{
    public static IHostBuilder UseLogging(this IHostBuilder hostBuilder, IConfiguration configuration)
        => hostBuilder.UseSerilog((context, loggerConfiguration) =>
            {

                var loggingOptions = configuration.GetSection("Logging").Get<LoggingOptions>();
                var applicationName = Assembly.GetEntryAssembly()?.FullName?.Split(',')[0].ToLowerInvariant() ?? string.Empty;

                loggerConfiguration.Enrich.FromLogContext()
                    .Enrich.WithProperty("Environment", context.HostingEnvironment.EnvironmentName)
                    .Enrich.WithProperty("ApplicationName", applicationName)
                    .WriteTo.Console();

                if (!string.IsNullOrWhiteSpace(loggingOptions?.Seq)) loggerConfiguration.WriteTo.Seq(loggingOptions.Seq);
            });
}
