using Lab.Auth.Persistence.Contexts;
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
        
        return services;    
    }
}