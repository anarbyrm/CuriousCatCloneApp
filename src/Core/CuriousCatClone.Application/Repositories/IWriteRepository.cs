using CuriousCatClone.Domain.Entities;

namespace CuriousCatClone.Application.Repositories
{
    public interface IWriteRepository<TEntity> where TEntity : BaseEntity
    {
        Task<bool> AddAsync(TEntity entity);
        Task<bool> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(TEntity entity);
    }
}
