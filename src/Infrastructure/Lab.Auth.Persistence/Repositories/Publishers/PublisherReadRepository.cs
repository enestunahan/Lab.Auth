using Lab.Auth.Application.Repositories.Publishers;
using Lab.Auth.Domain;
using Lab.Auth.Persistence.Contexts;

namespace Lab.Auth.Persistence.Repositories.Publishers;

public sealed class PublisherReadRepository(LabAuthDbContext context)
    : ReadRepository<Publisher>(context), IPublisherReadRepository;
