using System.Linq.Expressions;
using Lab.Auth.Domain.Common;

namespace Lab.Auth.Application.Repositories;

public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
{
    IQueryable<T> GetAll(bool tracking = true);

    IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate, bool tracking = true);

    Task<T?> GetSingleAsync(
        Expression<Func<T, bool>> predicate,
        bool tracking = true,
        CancellationToken cancellationToken = default);

    Task<T?> GetByIdAsync(
        Guid id,
        bool tracking = true,
        CancellationToken cancellationToken = default);
}
