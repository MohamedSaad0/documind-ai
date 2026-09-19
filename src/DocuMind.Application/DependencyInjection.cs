using DocuMind.Application.Documents.CreateDocument;
using DocuMind.Application.Documents.DeleteDocument;
using DocuMind.Application.Documents.GetDocument;
using DocuMind.Application.Documents.GetDocuments;
using Microsoft.Extensions.DependencyInjection;

namespace DocuMind.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<CreateDocumentService>();
            services.AddScoped<GetDocumentService>();
            services.AddScoped<GetDocumentsService>();
            services.AddScoped<DeleteDocumentService>();

            return services;
        }
    }
}
