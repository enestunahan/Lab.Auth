using MediatR;

namespace Lab.Auth.Application.Features.Books.Commands.DeleteBook;

public class DeleteBookCommand : IRequest<DeleteBookCommandResponse>
{
    public Guid Id { get; set; }
}

public class DeleteBookCommandResponse
{
    public bool Success { get; set; }
}
