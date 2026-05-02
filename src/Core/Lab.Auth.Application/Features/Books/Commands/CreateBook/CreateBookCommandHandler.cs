using Lab.Auth.Application.Repositories.Books;
using Lab.Auth.Domain;
using MediatR;

namespace Lab.Auth.Application.Features.Books.Commands.CreateBook;

public class CreateBookCommandHandler(IBookWriteRepository bookWriteRepository) : IRequestHandler<CreateBookCommand, CreateBookCommandResponse>
{
    public async Task<CreateBookCommandResponse> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var book = new Book
        {
            Title = request.Title,
            Description = request.Description,
            Isbn = request.Isbn,
            PublicationYear = request.PublicationYear,
            PublisherId = request.PublisherId
        };

        await bookWriteRepository.AddAsync(book, cancellationToken);
        await bookWriteRepository.SaveAsync(cancellationToken);

        return new CreateBookCommandResponse { Id = book.Id };
    }
}
