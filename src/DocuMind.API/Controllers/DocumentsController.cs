using DocuMind.Application.Documents.CreateDocument;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace DocuMind.API.Controllers;


[ApiController]
[Route("api/documents")]

public class Documentcontroller : ControllerBase
{
    private readonly CreateDocumentService _createDocumentService;

    public Documentcontroller(CreateDocumentService createDocumentService)
    {
        _createDocumentService = createDocumentService;
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
    public IActionResult GetById(Guid id)
    {
        return Ok();
    }
}