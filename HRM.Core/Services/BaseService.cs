using AutoMapper;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HRM.Core.Entities;
using HRM.Core.Interfaces.Repositories;
using HRM.Core.Interfaces.Services;

namespace ASI.Core.Services
{
    public class BaseService<TEntity, TKey, CreateDTO, DeleteDTO, DetailsDTO, EditDTO, IndexDTO>
              : IBaseService<TEntity, TKey, CreateDTO, DeleteDTO, DetailsDTO, EditDTO, IndexDTO>
      where TEntity : BaseEntity
      where TKey : IComparable
      where CreateDTO : class
      where DeleteDTO : class
      where DetailsDTO : class
      where EditDTO : class
      where IndexDTO : class
    {
        protected readonly IMapper _mapper;
        protected readonly IUnitOfWork _unitOfWork;

        public BaseService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public virtual async Task<int> Count(Expression<Func<TEntity, bool>> predicate = null)
        {
            try
            {
                return await _unitOfWork.repository.Count(predicate);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual async Task<bool> Create(CreateDTO createDTO)
        {
            try
            {
                var entity = _mapper.Map<TEntity>(createDTO);
                await _unitOfWork.repository.Add(entity);
                await _unitOfWork.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual async Task<bool> Delete(TKey Id)
        {
            try
            {
                var entity = await _unitOfWork.repository.Find<TEntity, TKey>(Id);
                _unitOfWork.repository.Remove(entity);
                await _unitOfWork.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual async Task<DetailsDTO> Details(TKey Id)
        {
            try
            {
                var entity = await _unitOfWork.repository.Find<TEntity, TKey>(Id);
                var detailsDTO = _mapper.Map<DetailsDTO>(entity);
                return detailsDTO;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual async Task<bool> Edit(EditDTO editDTO)
        {
            try
            {
                var entity = _mapper.Map<TEntity>(editDTO);
                _unitOfWork.repository.Update(entity);
                await _unitOfWork.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual async Task<FindDTO> Find<FindDTO>(TKey Id)
        {
            try
            {
                var entity = await _unitOfWork.repository.Find<TEntity, TKey>(Id);
                var findDTO = _mapper.Map<FindDTO>(entity);
                return findDTO;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual async Task<FindDTO> FirstFirstOrDefault<FindDTO>(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                var entity = await _unitOfWork.repository.FirstFirstOrDefault<TEntity>(predicate);
                var findDTO = _mapper.Map<FindDTO>(entity);
                return findDTO;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual async Task<FindDTO> FirstFirstOrDefault<FindDTO>(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            try
            {
                var entity = await _unitOfWork.repository.FirstFirstOrDefault<TEntity>(predicate, includes);
                var findDTO = _mapper.Map<FindDTO>(entity);
                return findDTO;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual async Task<IEnumerable<IndexDTO>> ToList(Expression<Func<TEntity, bool>> predicate = null)
        {
            var list = await _unitOfWork.repository.ToList(predicate);
            if (list == null) return new List<IndexDTO>();
            List<IndexDTO> indexList = new List<IndexDTO>();
            foreach (var item in list)
            {
                IndexDTO indexDTO = _mapper.Map<IndexDTO>(item);
                indexList.Add(indexDTO);
            }
            return indexList;
        }

        public virtual async Task<IEnumerable<IndexDTO>> ToList(params Expression<Func<TEntity, object>>[] includes)
        {
            var list = await _unitOfWork.repository.ToList<TEntity>(includes);
            if (list == null) return new List<IndexDTO>();
            List<IndexDTO> indexList = new List<IndexDTO>();
            foreach (var item in list)
            {
                IndexDTO indexDTO = _mapper.Map<IndexDTO>(item);
                indexList.Add(indexDTO);
            }
            return indexList;
        }

        public virtual async Task<IEnumerable<IndexDTO>> ToList(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            var list = await _unitOfWork.repository.ToList<TEntity>(predicate, includes);
            if (list == null) return new List<IndexDTO>();
            List<IndexDTO> indexList = new List<IndexDTO>();
            foreach (var item in list)
            {
                IndexDTO indexDTO = _mapper.Map<IndexDTO>(item);
                indexList.Add(indexDTO);
            }
            return indexList;
        }

        public virtual void ValidateBeforeCreate(CreateDTO dto, ModelStateDictionary modelState)
        {
            if (dto == null)
            {
                modelState.AddModelError("", "Entity can't be null.");
            }
        }

        public virtual void ValidateBeforeDelete(DeleteDTO dto, ModelStateDictionary modelState)
        {
            if (dto == null)
            {
                modelState.AddModelError("", "Entity can't be null.");
            }
        }

        public virtual void ValidateBeforeEdit(EditDTO dto, ModelStateDictionary modelState)
        {
            if (dto == null)
            {
                modelState.AddModelError("", "Entity can't be null.");
            }
        }
    }
}
