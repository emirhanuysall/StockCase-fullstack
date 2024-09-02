using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;

namespace Backend.Logging
{
    public static class SerilogLogging
    {
        public static void AddSerilogLogging(this IServiceCollection services)
        {
            // Serilog yapılandırmasını tanımlayın
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information() // Minimum log seviyesi
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning) // Microsoft logları için seviyeyi ayarla
                .MinimumLevel.Override("System", LogEventLevel.Warning) // System logları için seviyeyi ayarla
                .Enrich.FromLogContext() // Loglara ek bilgiler ekle
                .WriteTo.Console() // Logları konsola yaz
                .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day) // Logları dosyaya yaz
                .CreateLogger();

            services.AddLogging(builder =>
            {
                builder.AddSerilog(dispose: true);
            });
        }
    }
}


