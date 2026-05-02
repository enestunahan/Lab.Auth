using System.Linq.Expressions;
using Lab.Auth.Application.Repositories;
using Lab.Auth.Domain.Common;
using Lab.Auth.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Lab.Auth.Persistence.Repositories;

public class ReadRepository<T>(LabAuthDbContext context) : IReadRepository<T> where T : BaseEntity
{
    protected DbSet<T> Table => context.Set<T>();

    public IQueryable<T> GetAll(bool tracking = true)
    {
        IQueryable<T> query = Table;
        return tracking ? query : query.AsNoTracking();
    }

    public IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate, bool tracking = true)
    {
        IQueryable<T> query = Table.Where(predicate);
        return tracking ? query : query.AsNoTracking();
    }

    public Task<T?> GetSingleAsync(
        Expression<Func<T, bool>> predicate,
        bool tracking = true,
        CancellationToken cancellationToken = default)
    {
        IQueryable<T> query = tracking ? Table : Table.AsNoTracking();
        return query.FirstOrDefaultAsync(predicate, cancellationToken);
    }

    public Task<T?> GetByIdAsync(
        Guid id,
        bool tracking = true,
        CancellationToken cancellationToken = default)
    {
        IQueryable<T> query = tracking ? Table : Table.AsNoTracking();
        return query.FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken);
    }
}
