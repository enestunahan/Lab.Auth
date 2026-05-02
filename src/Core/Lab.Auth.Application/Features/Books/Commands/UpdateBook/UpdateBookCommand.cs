using MediatR;

namespace Lab.Auth.Application.Features.Books.Commands.UpdateBook;

public class UpdateBookCommand : IRequest<UpdateBookCommandResponse>
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string Isbn { get; set; } = string.Empty;
    public int PublicationYear { get; set; }
    public Guid PublisherId { get; set; }
}

public class UpdateBookCommandResponse
{
    public bool Success { get; set; }
}
