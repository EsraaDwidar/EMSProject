using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WorkShop.DAL.Repos
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext _Context;
        private readonly DbSet<T> _dbSet;

        public Repository(DbContext Context)
        {
            _Context = Context;
            _dbSet = _Context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            try
            {
                return _dbSet.AsNoTracking().ToList();
            }
            catch (Exception)
            {
                return Enumerable.Empty<T>();
                //return null;
            }
        }
        public T GetById(int id)
        {
            var name = _Context.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties.Select(x=>x.Name).Single();
            return _dbSet.AsNoTracking().FirstOrDefault(e => EF.Property<int>(e, name) == id);
            //return _dbSet.Find(id);
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }
        public void Update(T entity)
        {
            //_dbSet.Update(entity);
            _Context.Entry(entity).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            var removeditem = _dbSet.Find(id);
            if (removeditem != null)
            {
                _dbSet.Remove(removeditem);
            }
        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).AsNoTracking().ToList();
        }
        public IEnumerable<T> SelectAllWithIncluding(params string[] includes)
        { 
            IQueryable<T> query = _dbSet.AsNoTracking();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query.AsNoTracking().ToList();
        }
        public int Count()
        {
            try
            {
                return _dbSet.AsNoTracking().Count();
            }
            catch (Exception) 
            { 
                return -1;
            }
        }
    }
}
