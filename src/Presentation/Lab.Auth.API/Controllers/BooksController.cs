using Lab.Auth.Application.Features.Books.Queries.GetBooksList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lab.Auth.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetList(CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetBooksListQuery(), cancellationToken);
        return Ok(result);
    }
}
