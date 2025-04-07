using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkShop.DAL.Models;

namespace WorkShop.BL.Services.Interfaces
{
    public interface IService<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T Entity);
        void Update(T entity);
        void Delete(int id);
        int GetCounter();
    }
}
