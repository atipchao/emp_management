using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace emp_management.Models
{
    public class SQLCustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext context;
        public SQLCustomerRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Customer Add(Customer customer)
        {
            //throw new NotImplementedException();
            context.Customers.Add(customer);
            context.SaveChanges();
            return (customer);
        }

        public Customer Delete(int Id)
        {
            Customer cus = context.Customers.Find(Id);
            if (cus != null)
            {
                context.Customers.Remove(cus);
            }
            return (cus);
        }

        public IEnumerable<Customer> GetAllCustomer()
        {
            return (context.Customers);
        }

        public Customer GetCustomer(int Id)
        {
            Customer TargetCus = context.Customers.FirstOrDefault(t => t.Id == Id);
            return (TargetCus);
        }

        public Customer Update(Customer customerChange)
        {
            var cus = context.Customers.Attach(customerChange);
            cus.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return customerChange;
        }
    }
}
