using CuriousCatClone.Domain.Entities;
using System.Linq.Expressions;

namespace CuriousCatClone.Application.Repositories
{
    public interface IReadRepository<TEntity> where TEntity : BaseEntity
    {
        Task<IQueryable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IQueryable<TEntity>> GetWhereAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetByIdAsync(object id);
    }
}
