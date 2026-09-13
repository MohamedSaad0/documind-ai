using DocuMind.Application.Abstractions.Persistence;
using DocuMind.Application.Documents.CreateDocument;
using DocuMind.Infrastructure.Persistence;
using DocuMind.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

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

            return services;
        }
    }
}
