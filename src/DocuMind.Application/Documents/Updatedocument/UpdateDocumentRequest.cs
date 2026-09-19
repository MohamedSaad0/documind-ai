using System;
using System.Collections.Generic;
using System.Text;

namespace DocuMind.Application.Documents.Updatedocument
{
    public sealed record UpdateDocumentRequest(
        string Title,
        string Content,
        string DocumentType
        );
    
}
