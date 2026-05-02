using Lab.Auth.Application.Repositories.Categories;
using Lab.Auth.Domain;
using Lab.Auth.Persistence.Contexts;

namespace Lab.Auth.Persistence.Repositories.Categories;

public sealed class CategoryReadRepository(LabAuthDbContext context)
    : ReadRepository<Category>(context), ICategoryReadRepository;
