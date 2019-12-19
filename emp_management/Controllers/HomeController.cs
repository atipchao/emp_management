using emp_management.Models;
using emp_management.ViewModes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace emp_management.Controllers
{
    public class HomeController : Controller
    {
        private IEmployeeRepository _employeeRepository;

        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        //public JsonResult Index()
        public ViewResult Index()
        {
            IEnumerable<Employee> employees;
            employees = _employeeRepository.GetAllEmployee();
            return View(employees);
        }
        public ViewResult Details(int id)
        {
            Employee em = new Employee();

            em = _employeeRepository.GetEmployee(id);
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {

                Employee = em,
                PageTitle = "Emp Details"               

            };

            return View(homeDetailsViewModel);

        }
    }
}
