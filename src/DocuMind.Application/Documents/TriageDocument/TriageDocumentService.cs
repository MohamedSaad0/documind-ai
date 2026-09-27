using DocuMind.Application.Abstractions.AI;
using DocuMind.Application.Abstractions.Persistence;

namespace DocuMind.Application.Documents.TriageDocument
{
    public sealed  class TriageDocumentService
    {
        private readonly IKnowledgeDocumentRepository _repository;
        private readonly IAiAnalysisService _aiAnalysisService;

        public TriageDocumentService(IKnowledgeDocumentRepository repository, IAiAnalysisService aiAnalysisService)
        {
            _repository = repository;
            _aiAnalysisService = aiAnalysisService;
        }

        public async Task<TriageDocumentResponse?> ExecuteAsync(TriageDocumentRequest request, CancellationToken cancellationToken)
        {
            var document = await _repository.GetByIdAsync(request.DocumentId, cancellationToken);

            if (document is null)
            {
                return null;
            }

            var analysis = await _aiAnalysisService.AnalyzeAsync(document.Content, request.Question, cancellationToken);

            return new TriageDocumentResponse(request.DocumentId, request.Question, analysis.IsRelevant, analysis.Explanation);


        }
    }

}
