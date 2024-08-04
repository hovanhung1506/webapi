using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WebApi.Domain.Abstract
{
    public interface IRepository<T> where T : class
    {
        Task Insert(T entity);
        Task Insert(IEnumerable<T> entities);
        void Update(T entity);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> expression);
        Task<T> GetById(object id);
        Task<int> Commit();
        Task<IEnumerable<T>> GetData(Expression<Func<T, bool>> expression = null);
    }
}
