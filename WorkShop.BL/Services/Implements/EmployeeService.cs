using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkShop.BL.Services.Interfaces;
using WorkShop.DAL.Models;
using WorkShop.DAL.UnitOfWorks;

namespace WorkShop.BL.Services.Implements
{
    public class EmployeeService : IService<Employee>
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<Employee> GetAll()
        {
            return _unitOfWork.EmployeeRepository.GetAll();
            
        }
        public Employee GetById(int id)
        {
            return _unitOfWork.EmployeeRepository.GetById(id);
        }
        public void Add(Employee employee)
        {
            _unitOfWork.EmployeeRepository.Add(employee);
            _unitOfWork.Complete();
        }
        public void Update(Employee entity)
        {
                _unitOfWork.EmployeeRepository.Update(entity);
                _unitOfWork.Complete();
            
        }
        public void Delete(int id)
        {
            var employee = _unitOfWork.EmployeeRepository.GetById(id);
            if (employee != null)
            {
                _unitOfWork.EmployeeRepository.Delete(id);
                _unitOfWork.Complete();
            }
        }
        public int GetCounter()
        {
            return _unitOfWork.EmployeeRepository.Count();
        }
    }
}
