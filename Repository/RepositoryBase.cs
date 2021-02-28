using System;
using System.Linq;
using System.Linq.Expressions;
using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly FinalYearProjectDbContext _context;

        public RepositoryBase()
        {
            
        }
        
        public RepositoryBase(FinalYearProjectDbContext context)
        {
            _context = context;
        }
        
        public IQueryable<T> FindAll(bool trackChanges)
        {
            if (trackChanges)
            {
                return _context.Set<T>();
            }

            return _context.Set<T>()
                .AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            if (trackChanges)
            {
                return _context.Set<T>()
                    .Where(expression);
            }

            return _context.Set<T>()
                .Where(expression)
                .AsNoTracking();
        }

        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
    }
}