using Lab.Auth.Application.Repositories.Authors;
using Lab.Auth.Domain;
using Lab.Auth.Persistence.Contexts;

namespace Lab.Auth.Persistence.Repositories.Authors;

public sealed class AuthorReadRepository(LabAuthDbContext context)
    : ReadRepository<Author>(context), IAuthorReadRepository;
