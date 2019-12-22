using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace emp_management.Models
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext context;
        public SQLEmployeeRepository(AppDbContext context)
        {
            this.context = context;
        }

        public AppDbContext Context { get; }

        public Employee Add(Employee employee)
        {
            //throw new NotImplementedException();
            context.Employees.Add(employee);
            context.SaveChanges();
            return (employee);


        }

        public Employee Delete(int Id)
        {
            //throw new NotImplementedException();
            Employee emp = context.Employees.Find(Id);
            if(emp != null)
            {
                context.Employees.Remove(emp);
            }
            return (emp);

        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            //throw new NotImplementedException();
            return (context.Employees);
        }

        public Employee GetEmployee(int Id)
        {
            //throw new NotImplementedException();
            Employee TargetEmp = context.Employees.FirstOrDefault(t => t.Id == Id);
            return (TargetEmp);
        }

        public Employee Update(Employee employeeChange)
        {
            //throw new NotImplementedException();
            Employee TargetEmp = context.Employees.FirstOrDefault(t => t.Id == employeeChange.Id);
            if(TargetEmp != null)
            {
                TargetEmp = employeeChange;
                context.SaveChanges();
            }
            return (TargetEmp);
        }
    }
}
