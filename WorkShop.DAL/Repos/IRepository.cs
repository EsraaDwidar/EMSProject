using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WorkShop.DAL.Repos
{
    public interface IRepository<T> where T : class
    {
        //operation CRUD
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Update(T entity);
        void Delete(int id);
        void Add(T entity);
        IEnumerable<T> Find(Expression<Func<T,bool>> predicate);
        int Count();
        //using include for eager loading
        IEnumerable<T> SelectAllWithIncluding(params string[] includes);
    }
}
