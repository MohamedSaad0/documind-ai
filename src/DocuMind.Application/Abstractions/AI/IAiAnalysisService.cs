using System;
using System.Collections.Generic;
using System.Text;

namespace DocuMind.Application.Abstractions.AI
{
    public interface IAiAnalysisService
    {
        Task<AiAnalysisResult> AnalyzeAsync(
            string documentContent,
            string question,
            CancellationToken cancellationToken = default);

    }
}
