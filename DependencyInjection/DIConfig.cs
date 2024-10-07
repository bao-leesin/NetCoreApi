using Serilog;
using Serilog.Sinks.Elasticsearch;
using Service.Configuration;

namespace WebAPI.DependencyInjection
{
    public static class DIConfig
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            // Bind configuration
            var elasticConfiguration = new ElasticSearchConfiguration();
            configuration.GetSection(nameof(ElasticSearchConfiguration)).Bind(elasticConfiguration);
            if (elasticConfiguration.Uri == null)
            {
                return;
            }
            services.AddSingleton<ElasticSearchConfiguration>(elasticConfiguration);
            // Configure Serilog
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(elasticConfiguration.Uri))
                {
                    AutoRegisterTemplate = true,
                    IndexFormat = "logstash-{0:yyyy.MM.dd}"
                })
                .CreateLogger();
        }
    }
}
