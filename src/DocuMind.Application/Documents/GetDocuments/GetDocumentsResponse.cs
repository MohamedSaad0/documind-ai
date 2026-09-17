using System;
using System.Collections.Generic;
using System.Text;

namespace DocuMind.Application.Documents.GetDocuments
{
    public sealed record GetDocumentsResponse(
        Guid Id,
        string Title,
        string DocumentType,
        DateTime CreatedAt
        );
}
