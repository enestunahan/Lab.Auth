using Lab.Auth.Application.Repositories.Books;
using MediatR;

namespace Lab.Auth.Application.Features.Books.Commands.UpdateBook;

public class UpdateBookCommandHandler(
    IBookReadRepository bookReadRepository,
    IBookWriteRepository bookWriteRepository) : IRequestHandler<UpdateBookCommand, UpdateBookCommandResponse>
{
    public async Task<UpdateBookCommandResponse> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var book = await bookReadRepository.GetByIdAsync(request.Id, cancellationToken: cancellationToken);
        if (book is null)
            return new UpdateBookCommandResponse { Success = false };

        book.Title = request.Title;
        book.Description = request.Description;
        book.Isbn = request.Isbn;
        book.PublicationYear = request.PublicationYear;
        book.PublisherId = request.PublisherId;

        bookWriteRepository.Update(book);
        await bookWriteRepository.SaveAsync(cancellationToken);

        return new UpdateBookCommandResponse { Success = true };
    }
}
