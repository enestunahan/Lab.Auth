using MediatR;

namespace Lab.Auth.Application.Features.Books.Queries.GetBooksList;

public class GetBooksListQuery : IRequest<List<GetBooksListQueryResponse>>
{

}

public class GetBooksListQueryResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string Isbn { get; set; } = string.Empty;
    public int PublicationYear { get; set; }
}
