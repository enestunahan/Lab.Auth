using Lab.Auth.Application.Repositories;
using Lab.Auth.Domain.Common;
using Lab.Auth.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Lab.Auth.Persistence.Repositories;

public class WriteRepository<T>(LabAuthDbContext context) : IWriteRepository<T> where T : BaseEntity
{
    protected DbSet<T> Table => context.Set<T>();

    public async Task<bool> AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        EntityEntry<T> entry = await Table.AddAsync(entity, cancellationToken);
        return entry.State == EntityState.Added;
    }

    public async Task<bool> AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        await Table.AddRangeAsync(entities, cancellationToken);
        return true;
    }

    public bool Remove(T entity)
    {
        EntityEntry<T> entry = Table.Remove(entity);
        return entry.State == EntityState.Deleted;
    }

    public bool RemoveRange(IEnumerable<T> entities)
    {
        Table.RemoveRange(entities);
        return true;
    }

    public async Task<bool> RemoveAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await Table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        return entity is not null && Remove(entity);
    }

    public bool Update(T entity)
    {
        EntityEntry<T> entry = Table.Update(entity);
        return entry.State == EntityState.Modified;
    }

    public Task<int> SaveAsync(CancellationToken cancellationToken = default)
        => context.SaveChangesAsync(cancellationToken);
}
