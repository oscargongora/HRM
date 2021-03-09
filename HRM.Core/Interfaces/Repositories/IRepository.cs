using HRM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HRM.Core.Interfaces.Repositories
{
    public interface IRepository
    {
        Task Add<TEntity>(TEntity entity) where TEntity : BaseEntity;

        Task<int> Count<TEntity>(Expression<Func<TEntity, bool>> predicate = null) where TEntity : BaseEntity;

        Task<TEntity> Find<TEntity, TKey>(TKey id) where TEntity : BaseEntity where TKey : IComparable;

        Task<TEntity> FirstFirstOrDefault<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : BaseEntity;

        Task<TEntity> FirstFirstOrDefault<TEntity>(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes) where TEntity : BaseEntity;

        DbSet<TEntity> GetSet<TEntity>() where TEntity : BaseEntity;

        IQueryable<TEntity> GetSetAsQuery<TEntity>() where TEntity : BaseEntity;

        void Remove<TEntity>(TEntity entity) where TEntity : BaseEntity;

        Task<IEnumerable<TEntity>> ToList<TEntity>(Expression<Func<TEntity, bool>> predicate = null) where TEntity : BaseEntity;

        Task<IEnumerable<TEntity>> ToList<TEntity>(params Expression<Func<TEntity, object>>[] includes) where TEntity : BaseEntity;

        Task<IEnumerable<TEntity>> ToList<TEntity>(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes) where TEntity : BaseEntity;

        void Update<TEntity>(TEntity entity) where TEntity : BaseEntity;
    }
}
