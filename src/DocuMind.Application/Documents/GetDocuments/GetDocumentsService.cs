using DocuMind.Application.Abstractions.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace DocuMind.Application.Documents.GetDocuments
{
    public sealed class GetDocumentsService
    {
        public readonly IKnowledgeDocumentRepository _repository;

        public GetDocumentsService(IKnowledgeDocumentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IReadOnlyList<GetDocumentsResponse>> ExcuteAysnc(CancellationToken cancellationToken = default) 
        {
            var documents = await _repository.GetAllAysnc(cancellationToken);

            return documents.Select(document => new GetDocumentsResponse(
                document.Id,
                document.Title,
                document.DocumentType,
                document.CreatedAt
                )).ToList();
        }
    }
}
