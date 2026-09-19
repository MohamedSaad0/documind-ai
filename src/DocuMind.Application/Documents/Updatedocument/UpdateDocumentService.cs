using DocuMind.Application.Abstractions.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace DocuMind.Application.Documents.Updatedocument
{
    public class UpdateDocumentService
    {
        private readonly IKnowledgeDocumentRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateDocumentService(IKnowledgeDocumentRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<UpdateDocumentResponse?> ExecuteAsync(
            Guid id,
            UpdateDocumentRequest request,
            CancellationToken cancellationToken
            )
        {
            var document = await _repository.GetByIdForUpdateAsync(id, cancellationToken);

            if(document is null)
            {
                return null;
            }

            document.update(
                request.Title,
                request.Content,
                request.DocumentType);

            await _unitOfWork.SaveChangesAysnc(cancellationToken);

            return new UpdateDocumentResponse(
                document.Id,
                document.Title,
                document.Content,
                document.DocumentType,
                document.CreatedAt
                );
        }
    }
}
