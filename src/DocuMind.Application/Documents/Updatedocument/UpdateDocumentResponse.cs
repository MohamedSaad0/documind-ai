using System;
using System.Collections.Generic;
using System.Text;

namespace DocuMind.Application.Documents.Updatedocument
{
    public sealed record UpdateDocumentResponse(
        Guid Id,
        string Title,
        string Content,
        string DocumentType,
        DateTime CreatedAt
        );
}
