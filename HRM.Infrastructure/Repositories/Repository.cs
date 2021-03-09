using HRM.Core.Entities;
using HRM.Core.Interfaces.Repositories;
using HRM.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HRM.Infrastructure.Repositories
{
    public class Repository : IRepository
    {
        protected readonly HRMDbContext _context;

        public Repository(HRMDbContext context)
        {
            _context = context;
        }

        public async Task Add<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public async Task<int> Count<TEntity>(Expression<Func<TEntity, bool>> predicate = null) where TEntity : BaseEntity
        {
            if (predicate != null)
            {
                return await _context.Set<TEntity>().CountAsync(predicate);
            }
            return await _context.Set<TEntity>().CountAsync();
        }

        public async Task<TEntity> Find<TEntity, TKey>(TKey id)
            where TEntity : BaseEntity
            where TKey : IComparable
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> FirstFirstOrDefault<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : BaseEntity
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public async Task<TEntity> FirstFirstOrDefault<TEntity>(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes) where TEntity : BaseEntity
        {
            var query = _context.Set<TEntity>().AsQueryable();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return await query.FirstOrDefaultAsync(predicate);
        }

        public DbSet<TEntity> GetSet<TEntity>() where TEntity : BaseEntity
        {
            return _context.Set<TEntity>();
        }

        public IQueryable<TEntity> GetSetAsQuery<TEntity>() where TEntity : BaseEntity
        {
            return _context.Set<TEntity>().AsQueryable();
        }

        public void Remove<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public async Task<IEnumerable<TEntity>> ToList<TEntity>(Expression<Func<TEntity, bool>> predicate = null) where TEntity : BaseEntity
        {
            if (predicate != null)
            {
                return await _context.Set<TEntity>().Where(predicate).ToListAsync();
            }
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> ToList<TEntity>(params Expression<Func<TEntity, object>>[] includes) where TEntity : BaseEntity
        {
            var query = _context.Set<TEntity>().AsQueryable();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> ToList<TEntity>(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes) where TEntity : BaseEntity
        {
            var query = _context.Set<TEntity>().Where(predicate);
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return await query.ToListAsync();
        }

        public void Update<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            _context.Set<TEntity>().Update(entity);
        }
    }
}
