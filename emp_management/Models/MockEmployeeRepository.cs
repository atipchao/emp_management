using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace emp_management.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {

        private List<Employee> _employeeList;

        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>
            {
            new Employee() {Id =1, Name="OneFName", Department="HR", Email="Emp1@email.com"},
            new Employee() { Id = 2, Name = "TwoFName", Department = "IT", Email = "Emp2@email.com" },
            new Employee() { Id = 3, Name = "ThreeFName", Department = "IT", Email = "Emp3@email.com" }
            };
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return (_employeeList);
        }

        public Employee GetEmployee(int Id)
        {
            //throw new NotImplementedException();
            return _employeeList.FirstOrDefault(a => a.Id == Id);
        }
    }
}
