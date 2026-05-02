using Lab.Auth.Application.Features.Books.Commands.CreateBook;
using Lab.Auth.Application.Features.Books.Commands.DeleteBook;
using Lab.Auth.Application.Features.Books.Commands.UpdateBook;
using Lab.Auth.Application.Features.Books.Queries.GetBooksList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lab.Auth.API.Controllers.Admin;

[ApiController]
[Route("api/admin/books")]
public class BooksController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetList(CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetBooksListQuery(), cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateBookCommand command, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateBookCommand command, CancellationToken cancellationToken)
    {
        command.Id = id;
        var result = await mediator.Send(command, cancellationToken);
        if (!result.Success)
            return NotFound();
        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new DeleteBookCommand { Id = id }, cancellationToken);
        if (!result.Success)
            return NotFound();
        return Ok(result);
    }
}
