using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace emp_management.ViewModes
{
    public class EditRoleViewModel
    {
        public EditRoleViewModel()
        {
            Users = new List<string>(); // here we initialize the Users 
        }
        public string Id { get; set; }
        [Required(ErrorMessage = "Role name is required..")]
        public string RoleName { get; set; }
        public List<string> Users { get; set; }  
    }
}
