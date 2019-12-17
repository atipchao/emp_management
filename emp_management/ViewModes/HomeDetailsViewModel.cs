using emp_management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace emp_management.ViewModes
{
    //Holding only DTO - data transfer object
    public class HomeDetailsViewModel
    {
        public Employee Employee { get; set; }
        public string PageTitle { get; set; }
        //public CurrentProject currentProject { get; set; }
    }
}
