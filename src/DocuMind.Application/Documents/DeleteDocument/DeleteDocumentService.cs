using DocuMind.Application.Abstractions.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace DocuMind.Application.Documents.DeleteDocument
{
    public sealed class DeleteDocumentService
    {
        private readonly IKnowledgeDocumentRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteDocumentService(IKnowledgeDocumentRepository repository,
        IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> ExecuteAysnc(Guid id, CancellationToken cancellationToken)
        {
            var document = await _repository.GetByIdAsync(id, cancellationToken);

            if(document is null)
            {
                return false;
            }

            _repository.Remove(document);
            await _unitOfWork.SaveChangesAysnc(cancellationToken);

            return true;
        }
    }
}
