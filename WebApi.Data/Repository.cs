using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebApi.Data;
using WebApi.Domain.Abstract;

namespace WebApi.Domain
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly WebApiContext _context;

        public Repository(WebApiContext context)
        {
            _context = context;
        }

        public void Delete(T entity)
        {
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
        }

        public void Delete(Expression<Func<T, bool>> expression)
        {
            var entites = _context.Set<T>().Where(expression).ToList();
            if(entites.Count > 0)
            {
                _context.Set<T>().RemoveRange(entites);
            }
        }

        public async Task<IEnumerable<T>> GetData(Expression<Func<T, bool>> expression = null)
        {
            if(expression == null)
            {
                return await _context.Set<T>().ToListAsync();
            }
            return await _context.Set<T>().Where(expression).ToListAsync();
        }

        public async Task<T> GetById(object id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task Insert(T entity)
        {
            await _context.Set<T>().AddAsync(entity);

        }

        public async Task Insert(IEnumerable<T> entities)
        {
           await _context.Set<T>().AddRangeAsync(entities);
        }

        public void Update(T entity)
        {
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public IQueryable<T> Table => _context.Set<T>();

        public async Task<int> Commit()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
