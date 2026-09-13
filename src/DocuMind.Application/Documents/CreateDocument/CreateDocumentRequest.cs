using System;
using System.Collections.Generic;
using System.Text;

namespace DocuMind.Application.Documents.CreateDocument
{
    public sealed record CreateDocumentRequest(
        string Title,
        string ContentType,
        string DocumentType
        );
}