
using Applica.Domain.Entities;
using Applica.Domain.IRepositories;
using Applica.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Applica.Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    {
        protected readonly MongoContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(MongoContext context)
        {
            this._context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            var id = entity.Id;
            var ent = await _dbSet.FindAsync(id);
            if (ent != null)
            {
                _dbSet.Remove(ent);
                await _context.SaveChangesAsync();
            }
        }

        public virtual async Task<IEnumerable<TEntity>> FindAsync(Func<TEntity, bool> predicate)
        {
            var entities = await _dbSet.ToListAsync();

            return entities.Where(predicate).AsEnumerable();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<TEntity?> GetByIdAsync(string id)
        {
             return await _dbSet.FindAsync(id);
            
        }
    }
}
 