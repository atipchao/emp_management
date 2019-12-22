using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace emp_management.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder, int count)
        {
            if (count == 1)
            {
                modelBuilder.Entity<Employee>().HasData(

                    new Employee
                    {
                        Id = 1,
                        Name = "Joe",
                        Email = "Joe@mail.com",
                        Department = Dept.IT
                    }
                    );
            }
            else
            {
                modelBuilder.Entity<Employee>().HasData(

                    new Employee
                    {
                        Id = 1,
                        Name = "Joe",
                        Email = "Joe@mail.com",
                        Department = Dept.IT
                    },
                    new Employee
                    {
                        Id = 2,
                        Name = "Jane",
                        Email = "Jane@mail.com",
                        Department = Dept.HR
                    }
                    );
            }
        }
    }
}
