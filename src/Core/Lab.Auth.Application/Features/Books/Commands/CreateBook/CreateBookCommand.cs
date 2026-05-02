using MediatR;

namespace Lab.Auth.Application.Features.Books.Commands.CreateBook;

public class CreateBookCommand : IRequest<CreateBookCommandResponse>
{
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string Isbn { get; set; } = string.Empty;
    public int PublicationYear { get; set; }
    public Guid PublisherId { get; set; }
}

public class CreateBookCommandResponse
{
    public Guid Id { get; set; }
}
