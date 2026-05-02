using Lab.Auth.Application.Repositories.Books;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Lab.Auth.Application.Features.Books.Queries.GetBooksList;

public class GetBooksListQueryHandler(IBookReadRepository bookReadRepository) : IRequestHandler<GetBooksListQuery, List<GetBooksListQueryResponse>>
{
    public async Task<List<GetBooksListQueryResponse>> Handle(GetBooksListQuery request, CancellationToken cancellationToken)
    {
        var query = bookReadRepository.GetAll(tracking: false);

        var data = await query.Select(x => new GetBooksListQueryResponse
        {
            Id = x.Id,
            Title = x.Title,
            Description = x.Description,
            Isbn = x.Isbn,
            PublicationYear = x.PublicationYear
        }).ToListAsync(cancellationToken);

        return data;
    }
}
