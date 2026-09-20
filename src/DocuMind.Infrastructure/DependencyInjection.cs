using DocuMind.Application.Abstractions.AI;
using DocuMind.Application.Abstractions.Persistence;
using DocuMind.Infrastructure.AI.Ollama;
using DocuMind.Infrastructure.Persistence;
using DocuMind.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;


namespace DocuMind.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<
                DocuMindDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<
                IKnowledgeDocumentRepository,
                KnowledgeDocumentRepository>();

            services.AddScoped<
                IUnitOfWork,
                UnitOfWork>();

            services.AddHttpClient<OllamaAiAnalysisService>((serviceProvider, client) =>
            {
                var options = serviceProvider.GetRequiredService<IOptions<OllamaOptions>>().Value;
                client.BaseAddress = new Uri(options.BaseUrl);
            });

            services.AddScoped<IAiAnalysisService, OllamaAiAnalysisService>();

            services.Configure<OllamaOptions>(configuration.GetSection("ollama"));

            return services;
        }
    }
}
