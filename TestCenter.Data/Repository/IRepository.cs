using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TestCenter.Data.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        IQueryable GetByProperty(Expression<Func<T, bool>> expression);
        void Insert(T id);
        void Update(T obj);
        void Delete(object id);
    }

    public class Repository<T> : IRepository<T> where T : class
    {
        private DbContext _context;
        private DbSet<T> entity = null;

        public Repository(DbContext dbContext)
        {
            _context = dbContext;
            entity = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return entity.ToList();
        }

        public T GetById(object id)
        {
            return entity.Find(id);
        }

        public IQueryable GetByProperty(Expression<Func<T, bool>> expression)
        {
            return entity.Where(expression);
        }

        public void Insert(T obj)
        {
            entity.Add(obj);
        }

        public void Update(T obj)
        {
            entity.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            T existingObject = entity.Find(id);
            entity.Remove(existingObject);
        }
    }
}
