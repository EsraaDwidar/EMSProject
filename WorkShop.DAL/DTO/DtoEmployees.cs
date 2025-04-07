using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkShop.DAL.DTO
{
    public class DtoEmployees
    {
        public int EmployessId { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        public string Role { get; set; }
        public string? Department { get; set; }
        public decimal Salary { get; set; }
    }
}
