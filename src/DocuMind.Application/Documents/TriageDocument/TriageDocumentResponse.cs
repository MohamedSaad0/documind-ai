using System;
using System.Collections.Generic;
using System.Text;

namespace DocuMind.Application.Documents.TriageDocument
{
    public sealed record TriageDocumentResponse
    (
        Guid DocumentId,
        string Question,
        bool IsRelevant,
        string Explanation
    );
}
