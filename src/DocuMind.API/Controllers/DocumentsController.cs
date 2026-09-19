using DocuMind.Application.Documents.CreateDocument;
using DocuMind.Application.Documents.DeleteDocument;
using DocuMind.Application.Documents.GetDocument;
using DocuMind.Application.Documents.GetDocuments;
using Microsoft.AspNetCore.Mvc;


namespace DocuMind.API.Controllers;


[ApiController]
[Route("api/documents")]

public class Documentcontroller : ControllerBase
{
    private readonly CreateDocumentService _createDocumentService;
    private readonly GetDocumentService _getDocumentService;
    private readonly GetDocumentsService _getDocumentsService;
    private readonly DeleteDocumentService _deleteDocumentService;

    public Documentcontroller(CreateDocumentService createDocumentService,
        GetDocumentService getDocumentService,
        GetDocumentsService getDocumentsService,
        DeleteDocumentService deleteDocumentService
        )
    {
        _createDocumentService = createDocumentService;
        _getDocumentService = getDocumentService;
        _getDocumentsService = getDocumentsService;
        _deleteDocumentService = deleteDocumentService;
    }

    [HttpPost]
    public async Task<ActionResult<CreateDocumentResponse>> Create(
        CreateDocumentRequest request,
        CancellationToken cancellationToken
        )
    {
        var response = await _createDocumentService.ExecuteAysnc(request, cancellationToken);

        return CreatedAtAction(
            nameof(GetById),
            new { id = response.Id },
            response);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<GetDocumentResponse>> GetById(Guid id,  CancellationToken cancellationToken) 
    {
        var response = await _getDocumentService.ExecuteAsync(id, cancellationToken);

        if(response is null)
        { return  NotFound(); }

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<GetDocumentsResponse>>> GetAll(CancellationToken cancellationToken)
    {
        var response = await _getDocumentsService.ExcuteAysnc(cancellationToken);

        return Ok(response);
    }

    [HttpDelete("{id:guid}")]

    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var deleted = await _deleteDocumentService.ExecuteAysnc(id, cancellationToken);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}