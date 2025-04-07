//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using WorkShop.BL.Services.Implements;
//using WorkShop.BL.Services.Interfaces;
//using WorkShop.DAL.Models;

//namespace EApp.Pl.Controllers
//{
//    [ApiController]
//    [Route("[controller]")]
//    [Authorize]
//    public class DepartmentsController : ControllerBase
//    {
//        private readonly IService<Department> _departmentService;
//        public DepartmentsController(IService<Department> departmentService)
//        {
//            _departmentService = departmentService;
//        }
//        [HttpGet("GetDepartments")]
//        [Authorize(Roles = "Patient,Doctor,Admin")]
//        public IActionResult GetDepartments()
//        {
//            var departments = _departmentService.GetAll();
//            return Ok(departments);
//        }
//        [HttpGet("{id}")]
//        public IActionResult GetDepartment(int id)
//        {
//            var department = _departmentService.GetById(id);
//            return Ok(department);
//        }
//        [HttpPut]
//        public IActionResult UpdateDepartment(Department department)
//        {
//            if (department == null) { return BadRequest(); }
//            else
//            {
//                _departmentService.Update(department);

//                return Ok();
//            }
//        }
//        [HttpDelete("{id}")]
//        public IActionResult DeletwDepartment(int id)
//        {
//            if (id == null) { return BadRequest(); }
//            else
//            {
//                _departmentService.Delete(id);

//                return NoContent();
//            }
//        }
//        [HttpPost]
//        [Authorize(Roles = "Admin")]
//        public IActionResult AddDepartment(Department dep)
//        {
//            _departmentService.Add(dep);
//            return Ok();
//        }
//    }
//}
