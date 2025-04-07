using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WorkShop.BL.Services.Interfaces;
using WorkShop.DAL.Models;

namespace EApp.Pl.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class EmployeesController : ControllerBase
    {
        private readonly IService<Employee> _employeeService;
        public EmployeesController(IService<Employee> employeeService)
        {
            _employeeService = employeeService;
        }
        // GET: api/<EmployeesController>
        [HttpGet]
        [Authorize(Roles ="Employee")]
        public IActionResult GetAll()
        {
                var employees = _employeeService.GetAll();
                return Ok(employees);
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Employee" )]
        public IActionResult GetEmployee(int id)
        {
                var employee = _employeeService.GetById(id);
                return Ok(employee);
        }

        // POST api/<EmployeesController>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddEmployee(Employee employee)
        {
            _employeeService.Add(employee);
            return Ok();
        }

        // PUT api/<EmployeesController>/5
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateDepartment(Employee employee)
        {
            _employeeService.Update(employee);
            return Ok();

        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeletwDepartment(int id)
        {
            if (id == null) { return BadRequest(); }
                else
                {
                    _employeeService.Delete(id);

                    return NoContent();
                }
        }
    }
}
