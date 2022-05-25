using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApp.Repositories.Interfaces;
using WebApp.Data;

namespace WebApp.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected WebDBContext webDBContext { get; set; }
        public RepositoryBase(WebDBContext _webDBContext)
        {
            this.webDBContext = _webDBContext;
        }
        public IQueryable<T> FindAll()
        {
            return this.webDBContext.Set<T>().AsNoTracking();
        }
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.webDBContext.Set<T>().Where(expression).AsNoTracking();
        }
        public void Create(T entity)
        {
            this.webDBContext.Set<T>().Add(entity);
        }
        public void Update(T entity)
        {
            this.webDBContext.Set<T>().Update(entity);
        }
        public void Delete(T entity)
        {
            this.webDBContext.Set<T>().Remove(entity);
        }


    }
}
