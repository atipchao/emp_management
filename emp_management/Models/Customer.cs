using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace emp_management.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [EmailAddress]
        [Required]
        [Display(Name = "Customer Email")]
        public string Email { get; set; }
        [Required]
        public MemberType MemberType { get; set; }
        public string PhotoPath { get; set; }
    }
}
