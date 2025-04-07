using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkShop.DAL.Models;
using WorkShop.DAL.Repos;

namespace WorkShop.DAL.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Employee> EmployeeRepository {  get; }
        int Complete();
    }
}
