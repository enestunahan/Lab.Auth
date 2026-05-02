using Lab.Auth.Application.Repositories.Books;
using MediatR;

namespace Lab.Auth.Application.Features.Books.Commands.DeleteBook;

public class DeleteBookCommandHandler(IBookWriteRepository bookWriteRepository) : IRequestHandler<DeleteBookCommand, DeleteBookCommandResponse>
{
    public async Task<DeleteBookCommandResponse> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var removed = await bookWriteRepository.RemoveAsync(request.Id, cancellationToken);
        if (!removed)
            return new DeleteBookCommandResponse { Success = false };

        await bookWriteRepository.SaveAsync(cancellationToken);
        return new DeleteBookCommandResponse { Success = true };
    }
}
