using Lab.Auth.Application.Repositories.Books;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Lab.Auth.Application.Features.Books.Queries.GetBookById;

public class GetBookByIdQueryHandler(IBookReadRepository bookReadRepository)
    : IRequestHandler<GetBookByIdQuery, GetBookByIdQueryResponse?>
{
    public async Task<GetBookByIdQueryResponse?> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        var data = await bookReadRepository.GetWhere(x => x.Id == request.Id, tracking: false)
            .Select(x => new GetBookByIdQueryResponse
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                Isbn = x.Isbn,
                PublicationYear = x.PublicationYear,
                PublisherId = x.PublisherId,
                PublisherName = x.Publisher != null ? x.Publisher.Name : null,
                Authors = x.BookAuthors
                    .OrderBy(ba => ba.Author != null ? ba.Author.LastName : string.Empty)
                    .ThenBy(ba => ba.Author != null ? ba.Author.FirstName : string.Empty)
                    .Select(ba => new GetBookByIdAuthorResponse
                    {
                        Id = ba.AuthorId,
                        FirstName = ba.Author != null ? ba.Author.FirstName : string.Empty,
                        LastName = ba.Author != null ? ba.Author.LastName : string.Empty
                    })
                    .ToList(),
                Categories = x.BookCategories
                    .OrderBy(bc => bc.Category != null ? bc.Category.Name : string.Empty)
                    .Select(bc => new GetBookByIdCategoryResponse
                    {
                        Id = bc.CategoryId,
                        Name = bc.Category != null ? bc.Category.Name : string.Empty
                    })
                    .ToList()
            })
            .FirstOrDefaultAsync(cancellationToken);

        return data;
    }
}
