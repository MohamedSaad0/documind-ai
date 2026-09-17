using DocuMind.Application.Abstractions.Persistence;

namespace DocuMind.Application.Documents.GetDocument
{
    public sealed class GetDocumentService
    {

        public readonly IKnowledgeDocumentRepository _repository;

        public GetDocumentService(IKnowledgeDocumentRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetDocumentResponse?> ExecuteAsync(
            Guid id,
            CancellationToken cancellationToken = default)
        {
            var document = await _repository.GetByIdAsync(id, cancellationToken);

            if (document is null)
            {
                return null;
            }

            return new GetDocumentResponse(
                document.Id,
                document.Title,
                document.Content,
                document.DocumentType,
                document.CreatedAt);
        }
    }
}
