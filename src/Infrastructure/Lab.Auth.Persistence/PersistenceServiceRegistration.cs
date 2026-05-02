using Lab.Auth.Application.Repositories;
using Lab.Auth.Application.Repositories.Authors;
using Lab.Auth.Application.Repositories.Books;
using Lab.Auth.Application.Repositories.Categories;
using Lab.Auth.Application.Repositories.Publishers;
using Lab.Auth.Persistence.Contexts;
using Lab.Auth.Persistence.Repositories;
using Lab.Auth.Persistence.Repositories.Authors;
using Lab.Auth.Persistence.Repositories.Books;
using Lab.Auth.Persistence.Repositories.Categories;
using Lab.Auth.Persistence.Repositories.Publishers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lab.Auth.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<LabAuthDbContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection")
                                   ?? throw new InvalidOperationException(
                                       "Connection string 'DefaultConnection' is required.");

            options.UseNpgsql(connectionString,
                sqlOptions => sqlOptions.MigrationsAssembly(typeof(LabAuthDbContext).Assembly.FullName));
        });

        services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
        services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));

        services.AddScoped<IBookReadRepository, BookReadRepository>();
        services.AddScoped<IBookWriteRepository, BookWriteRepository>();

        services.AddScoped<IAuthorReadRepository, AuthorReadRepository>();
        services.AddScoped<IAuthorWriteRepository, AuthorWriteRepository>();

        services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
        services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();

        services.AddScoped<IPublisherReadRepository, PublisherReadRepository>();
        services.AddScoped<IPublisherWriteRepository, PublisherWriteRepository>();

        return services;
    }
}