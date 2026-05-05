using MediatR;

namespace Lab.Auth.Application.Features.Books.Queries.GetBookById;

public class GetBookByIdQuery : IRequest<GetBookByIdQueryResponse?>
{
    public Guid Id { get; set; }
}

public class GetBookByIdQueryResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string Isbn { get; set; } = string.Empty;
    public int PublicationYear { get; set; }
    public Guid PublisherId { get; set; }
    public string? PublisherName { get; set; }
    public List<GetBookByIdAuthorResponse> Authors { get; set; } = [];
    public List<GetBookByIdCategoryResponse> Categories { get; set; } = [];
}

public class GetBookByIdAuthorResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}

public class GetBookByIdCategoryResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
