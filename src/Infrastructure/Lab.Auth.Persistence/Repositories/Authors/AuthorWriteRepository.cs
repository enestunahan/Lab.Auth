using Lab.Auth.Application.Repositories.Authors;
using Lab.Auth.Domain;
using Lab.Auth.Persistence.Contexts;

namespace Lab.Auth.Persistence.Repositories.Authors;

public sealed class AuthorWriteRepository(LabAuthDbContext context)
    : WriteRepository<Author>(context), IAuthorWriteRepository;
