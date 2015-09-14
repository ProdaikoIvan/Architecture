using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> _context;

        public GenericRepository(DbContext context)
        {
            _context = context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IQueryable<TEntity>> orderBy = null,
        params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _context;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            if (orderBy != null)
            {
                return await orderBy(query).AsNoTracking().ToListAsync();
            }

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _context.FindAsync(id);
        }

        //public void AddOrUpdate(TEntity entity)
        //{
        //    _context.AddOrUpdate(entity);
        //}

        public async Task AddOrUpdateAsync(TEntity entity)
        {
            await Task.Factory.StartNew(() => _context.AddOrUpdate(entity));
        }

        public async Task DeleteAsync(int id)
        {
            _context.Remove(await GetByIdAsync(id));
        }

        public async Task<int> CountAsync()
        {
            return await _context.CountAsync();
        }
    }
}