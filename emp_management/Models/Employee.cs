using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace emp_management.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [EmailAddress]
        [Required]
        [Display(Name = "Office Email")]
        public string Email { get; set; }
        [Required]
        public Dept Department { get; set; }
    }
}
