using System;
using System.Collections.Generic;
using System.Text;

namespace DocuMind.Application.Documents.CreateDocument
{
    public sealed record CreateDocumentResponse(
        Guid Id,
        string Title,
        string Content,
        string ContentType,
        DateTime CreatedAt
        );  
}
