using Lab.Auth.Domain.Common;

namespace Lab.Auth.Application.Repositories;

public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
{
    Task<bool> AddAsync(T entity, CancellationToken cancellationToken = default);

    Task<bool> AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);

    bool Remove(T entity);

    bool RemoveRange(IEnumerable<T> entities);

    Task<bool> RemoveAsync(Guid id, CancellationToken cancellationToken = default);

    bool Update(T entity);

    Task<int> SaveAsync(CancellationToken cancellationToken = default);
}
