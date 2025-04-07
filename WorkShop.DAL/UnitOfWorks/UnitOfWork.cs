using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkShop.DAL.Models;
using WorkShop.DAL.Repos;

namespace WorkShop.DAL.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WorkShopDbContext _dbContext;
        public IRepository<Employee> EmployeeRepository {  get; }
        //public IRepository<AppUser> UserRepository {  get; }
        public UnitOfWork(WorkShopDbContext dbContext)
        {
            _dbContext = dbContext;
            EmployeeRepository = new Repository<Employee>(_dbContext);
        }

        public int Complete()
        {
            var rows =  _dbContext.SaveChanges();
            _dbContext.ChangeTracker.Clear();
            return rows;
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
