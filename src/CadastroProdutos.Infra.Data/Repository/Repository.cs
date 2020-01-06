using CadastroProdutos.Domain.Interface.Repository;
using CadastroProdutos.Infra.Data.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CadastroProdutos.Infra.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;
        public Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Adds an entity
        /// </summary>
        /// <param name="entity">Entity to add</param>
        /// <returns></returns>
        public async Task AddAsync(T entity)
        {
            await _unitOfWork.Context.Set<T>().AddAsync(entity);
        }

        /// <summary>
        /// Deletes an entity
        /// </summary>
        /// <param name="entity">Entity to remove</param>
        /// <returns></returns>
        public async Task DeleteAsync(T entity)
        {
            T existing = await _unitOfWork.Context.Set<T>().FindAsync(entity);
            if (existing != null) _unitOfWork.Context.Set<T>().Remove(existing);
        }

        /// <summary>
        /// Updates an entity
        /// </summary>
        /// <param name="entity">Entity to update</param>
        public void Update(T entity)
        {
            _unitOfWork.Context.Entry(entity).State = EntityState.Modified;
            _unitOfWork.Context.Set<T>().Attach(entity);
        }

        /// <summary>
        /// Filter entities
        /// </summary>
        /// <param name="predicate">Conditions to filter</param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> FilterByAsync(Expression<Func<T, bool>> predicate)
        {
            var entities = _unitOfWork.Context.Set<T>().Where(predicate).AsEnumerable<T>();

            return await Task.FromResult(entities);
        }

        /// <summary>
        /// Find an entity
        /// </summary>
        /// <param name="predicate">Conditions to find an entity</param>
        /// <returns></returns>
        public async Task<T> FindByAsync(Expression<Func<T, bool>> predicate = null)
        {
            return await _unitOfWork.Context.Set<T>().Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> All()
        {
            return await _unitOfWork.Context.Set<T>().AsNoTracking().ToListAsync();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
