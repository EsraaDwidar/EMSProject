using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WorkShop.DAL.Models
{
    [Table("Employees")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
    }
}
