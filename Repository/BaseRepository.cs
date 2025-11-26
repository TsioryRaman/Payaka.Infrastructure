using Microsoft.EntityFrameworkCore;
using Payaka.Domain.Base;
using Payaka.Infrastructure.Database;
using Payaka.Infrastructure.Repository.Base;
using System.Linq.Expressions;

namespace Payaka.Infrastructure.Repository
{
    public class BaseRepository<TEntity, TContext> : IBaseRepository<TEntity> where TEntity : BaseEntity where TContext : CoreDbContext
    {
        private readonly TContext _dbContext;

        public BaseRepository(TContext context)
        {
            _dbContext = context;
        }

        #region Methods

        public async Task<TEntity> DeleteById(Guid id)
        {
            var entity = await GetById(id) ?? throw new Exception("Entity not found to delete");
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _dbContext.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> where)
        {
            return await _dbContext.Set<TEntity>().AsNoTracking().Where(where).ToListAsync();
        }

        public async Task<TEntity?> GetById(Guid id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        #endregion
    }
}
