using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace emp_management.Models
{
    public interface IEmployeeRepository
    {
        Employee GetEmployee(int Id); 
    }
}
