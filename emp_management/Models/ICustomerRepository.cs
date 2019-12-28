using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace emp_management.Models
{
    public interface ICustomerRepository
    {
        Customer GetCustomer(int Id);
        IEnumerable<Customer> GetAllCustomer();
        Customer Add(Customer customer);
        Customer Update(Customer customerChange);
        Customer Delete(int Id);
    }
}
