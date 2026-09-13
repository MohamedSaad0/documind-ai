using DocuMind.Application.Abstractions.Persistence;
using DocuMind.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DocuMind.Application.Documents.CreateDocument
{
    public sealed class CreateDocumentService
    {
        private readonly IKnowledgeDocumentRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateDocumentService(IKnowledgeDocumentRepository repository,  IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateDocumentResponse> ExecuteAysnc(CreateDocumentRequest request, CancellationToken cancellationToken)
        {
            var document = new KnowledgeDocument(
                request.Title,
                request.ContentType,
                request.DocumentType
                );

            _repository.Add(document);

            await _unitOfWork.SaveChangesAysnc(cancellationToken);

            return new CreateDocumentResponse(
                document.Id,
                document.Title,
                document.Content,
                document.DocumentType,
                document.CreatedAt
                );
        }

    }
}
