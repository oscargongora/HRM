using HRM.Core.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HRM.Core.Interfaces.Services
{
    public interface IBaseService<TEntity, TKey, CreateDTO, DeleteDTO, DetailsDTO, EditDTO, IndexDTO>
        where TEntity : BaseEntity
        where TKey : IComparable
        where CreateDTO : class
        where DeleteDTO : class
        where DetailsDTO : class
        where EditDTO : class
        where IndexDTO : class
    {
        Task<bool> Create(CreateDTO createDTO);
        Task<int> Count(Expression<Func<TEntity, bool>> predicate = null);
        Task<bool> Delete(TKey Id);
        Task<DetailsDTO> Details(TKey Id);
        Task<bool> Edit(EditDTO editDTO);
        Task<FindDTO> Find<FindDTO>(TKey Id);
        Task<FindDTO> FirstFirstOrDefault<FindDTO>(Expression<Func<TEntity, bool>> predicate);
        Task<FindDTO> FirstFirstOrDefault<FindDTO>(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);
        Task<IEnumerable<IndexDTO>> ToList(Expression<Func<TEntity, bool>> predicate = null);
        Task<IEnumerable<IndexDTO>> ToList(params Expression<Func<TEntity, object>>[] includes);
        Task<IEnumerable<IndexDTO>> ToList(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);
        void ValidateBeforeCreate(CreateDTO dto, ModelStateDictionary modelState);
        void ValidateBeforeDelete(DeleteDTO dto, ModelStateDictionary modelState);
        void ValidateBeforeEdit(EditDTO dto, ModelStateDictionary modelState);
    }
}
