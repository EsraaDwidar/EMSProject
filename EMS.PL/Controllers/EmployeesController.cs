//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using WorkShop.BL.Services.Interfaces;
//using WorkShop.DAL.Models;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace EMS.PL.Controllers
//{
//    //[ApiController]
//    //[Route("api/[controller]")]
//    //[Authorize]
//    //public class EmployeesController : ControllerBase
//    //{
//    //    private static List<Employee> employees = new List<Employee>();
//    //    private readonly IUserService _userService;

//    //    public EmployeesController(IUserService userService)
//    //    {
//    //        _userService = userService;
//    //    }

//    //    [HttpGet]
//    //    //[Authorize(Roles = "Patient,Doctor,Admin")]
//    //    public IActionResult GetEmployees()
//    //    {
//    //        var user = _userService.GetUser(User.Identity.Name);
//    //        if (user?.Role == "Patient" || user?.Role == "Doctor" || user?.Role == "Admin")
//    //        {
//    //            return Ok(employees); // Users can view employees
//    //        }
//    //        return Forbid(); // Forbidden for non-users
//    //    }

//    //    [HttpPost]
//    //    //[Authorize(Roles = "Admin")]
//    //    public IActionResult CreateEmployee([FromBody] Employee employee)
//    //    {
//    //        var user = _userService.GetUser(User.Identity.Name);
//    //        if (user?.Role == "Admin")
//    //        {
//    //            employees.Add(employee);
//    //            return CreatedAtAction(nameof(GetEmployees), new { id = employee.Id }, employee);
//    //        }
//    //        return Forbid(); // Forbidden for non-admins
//    //    }

//    //    [HttpPut("{id}")]
//    //    [Authorize(Roles = "Admin")]
//    //    public IActionResult UpdateEmployee(int id, [FromBody] Employee employee)
//    //    {
//    //        var user = _userService.GetUser(User.Identity.Name);
//    //        if (user?.Role == "Admin")
//    //        {
//    //            var existingEmployee = employees.FirstOrDefault(e => e.Id == id);
//    //            if (existingEmployee == null) return NotFound();
//    //            existingEmployee.Name = employee.Name;
//    //            return NoContent();
//    //        }
//    //        return Forbid(); // Forbidden for non-admins
//    //    }

//    //    [HttpDelete("{id}")]
//    //    //[Authorize(Roles = "Admin")]
//    //    public IActionResult DeleteEmployee(int id)
//    //    {
//    //        var user = _userService.GetUser(User.Identity.Name);
//    //        if (user?.Role == "Admin")
//    //        {
//    //            var employee = employees.FirstOrDefault(e => e.Id == id);
//    //            if (employee == null) return NotFound();
//    //            employees.Remove(employee);
//    //            return NoContent();
//    //        }
//    //        return Forbid(); // Forbidden for non-admins
//    //    }
//    //}
//    [Route("api/[controller]")]
//    [ApiController]
//    [Authorize]
//    public class EmployeesController : ControllerBase
//    {
//        private readonly IService<Employee> _employeeService;
//        //private readonly IUserService _userService;
//        public EmployeesController(IService<Employee> employeeService)
//        {
//            _employeeService = employeeService;
//            //_userService = userService;
//        }
//        // GET: api/<EmployeesController>
//        [HttpGet]
//        public IActionResult GetAll()
//        {
//                var employees = _employeeService.GetAll();
//                return Ok(employees);
//        }

//        // GET api/<EmployeesController>/5
//        [HttpGet("{id}")]
//        public IActionResult GetEmployee(int id)
//        {
//                var employee = _employeeService.GetById(id);
//                return Ok(employee);
//        }

//        // POST api/<EmployeesController>
//        [HttpPost]
//        public IActionResult AddEmployee(Employee employee)
//        {
//                _employeeService.Add(employee);
//                return Ok();

//        }

//        // PUT api/<EmployeesController>/5
//        [HttpPut]
//        public IActionResult UpdateDepartment(Employee employee)
//        {
//            _employeeService.Update(employee);
//            return Ok();

//        }

//        // DELETE api/<EmployeesController>/5
//        [HttpDelete("{id}")]
//        public IActionResult DeletwDepartment(int id)
//        {
//            if (id == null) { return BadRequest(); }
//            else
//            {
//                _employeeService.Delete(id);

//                return NoContent();
//            }
//        }
//    }
//}
