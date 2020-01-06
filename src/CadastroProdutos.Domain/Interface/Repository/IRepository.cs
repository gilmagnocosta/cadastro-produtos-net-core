using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CadastroProdutos.Domain.Interface.Repository
{
    public interface IRepository<T> : IDisposable where T : class
    {
        Task<IEnumerable<T>> All();
        Task<IEnumerable<T>> FilterByAsync(Expression<Func<T, bool>> predicate);
        Task<T> FindByAsync(Expression<Func<T, bool>> predicate = null);
        Task AddAsync(T entity);
        Task DeleteAsync(T entity);
        void Update(T entity);
    }
}