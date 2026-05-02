using Lab.Auth.Application.Repositories.Books;
using Lab.Auth.Domain;
using Lab.Auth.Persistence.Contexts;

namespace Lab.Auth.Persistence.Repositories.Books;

public sealed class BookWriteRepository(LabAuthDbContext context)
    : WriteRepository<Book>(context), IBookWriteRepository;
