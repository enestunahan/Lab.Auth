using Lab.Auth.Application.Repositories.Books;
using Lab.Auth.Domain;
using Lab.Auth.Persistence.Contexts;

namespace Lab.Auth.Persistence.Repositories.Books;

public sealed class BookReadRepository(LabAuthDbContext context)
    : ReadRepository<Book>(context), IBookReadRepository;
