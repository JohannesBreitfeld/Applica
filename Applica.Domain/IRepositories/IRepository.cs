using Applica.Domain.Entities;

namespace Applica.Domain.IRepositories;

public interface IRepository<TEntity> where TEntity : EntityBase
{

        Task<TEntity?> GetByIdAsync(string id);
      
        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<IEnumerable<TEntity>> FindAsync(Func<TEntity, bool> predicate);

        Task AddAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);

}
