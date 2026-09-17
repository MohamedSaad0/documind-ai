namespace DocuMind.Application.Documents.GetDocument
{
    public sealed record GetDocumentResponse(
        Guid Id,
        string Title,
        string Content,
        string DocumentType,
        DateTime CreatedAt
        );
}
