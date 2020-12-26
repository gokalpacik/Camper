using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Exceptions;
using Serilog.Sinks.Elasticsearch;
using System;

namespace Camper.Web.CampFinder
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
            .UseSerilog(((hostingContext, loggerConfiguration) =>
            {
                var env = hostingContext.HostingEnvironment;

                loggerConfiguration.MinimumLevel.Information()
                .Enrich.FromLogContext()
                .Enrich.WithProperty("EnvironmentName", env.EnvironmentName)
                .Enrich.WithExceptionDetails()
                .MinimumLevel.Override("Microsoft", (LogEventLevel)LogLevel.Warning)
                .MinimumLevel.Override("System.Net.Http.HttpClient", (LogEventLevel)LogLevel.Warning)
                .MinimumLevel.Override("Microsoft.Hosting.Lifetime", (LogEventLevel)LogLevel.Information)
                .WriteTo.Console();

                if (hostingContext.HostingEnvironment.IsDevelopment())
                {
                    loggerConfiguration.MinimumLevel.Override("Camper", LogEventLevel.Debug);
                }

                var elasticUrl = hostingContext.Configuration.GetValue<string>("Logging:ElasticUrl");

                if (!string.IsNullOrEmpty(elasticUrl))
                {
                    loggerConfiguration.WriteTo.Elasticsearch(
                        new ElasticsearchSinkOptions(new Uri(elasticUrl))
                        {
                            AutoRegisterTemplate = true,
                            AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv7,
                            IndexFormat = "camper-logs-{0:dd.MM.yyyy}",
                            MinimumLogEventLevel = LogEventLevel.Debug
                        });
                }

            }));
    }
}
