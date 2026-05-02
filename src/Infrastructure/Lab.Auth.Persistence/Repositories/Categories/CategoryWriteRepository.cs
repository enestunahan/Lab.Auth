using Lab.Auth.Application.Repositories.Categories;
using Lab.Auth.Domain;
using Lab.Auth.Persistence.Contexts;

namespace Lab.Auth.Persistence.Repositories.Categories;

public sealed class CategoryWriteRepository(LabAuthDbContext context)
    : WriteRepository<Category>(context), ICategoryWriteRepository;


