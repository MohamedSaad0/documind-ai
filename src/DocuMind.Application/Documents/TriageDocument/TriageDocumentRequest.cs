using System;
using System.Collections.Generic;
using System.Text;

namespace DocuMind.Application.Documents.TriageDocument
{
    public sealed record TriageDocumentRequest
    (
        Guid DocumentId,
        string Question
     );
}
