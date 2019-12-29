﻿using emp_management.Models;
using emp_management.ViewModes;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace emp_management.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IHostingEnvironment _hostingEnvironment;

        public HomeController(IEmployeeRepository employeeRepository, IHostingEnvironment hostingEnvironment)
        {
            _employeeRepository = employeeRepository;
            _hostingEnvironment = hostingEnvironment;
        }

        //public JsonResult Index()

        public ViewResult Index()
        {
            IEnumerable<Employee> employees;
            employees = _employeeRepository.GetAllEmployee();
            return View(employees);
        }

        public ViewResult Details(int? id)
        {
            Employee em = new Employee();

            em = _employeeRepository.GetEmployee(id ?? 1);
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {

                Employee = em,
                PageTitle = "Emp Details"

            };

            return View(homeDetailsViewModel);
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        //public RedirectToActionResult Create(Employee emp)
        public ActionResult Create(EmpCreateViweModel emp)
        {
            if (ModelState.IsValid)
            {
                string uniqueFilename = null;
                if (emp.Photos != null && emp.Photos.Count > 0)
                {
                    foreach (IFormFile photo in emp.Photos)
                    {
                        string uploadFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                        uniqueFilename = Guid.NewGuid().ToString() + "_" + photo.FileName;
                        string filePath = Path.Combine(uploadFolder, uniqueFilename);
                        photo.CopyTo(new FileStream(filePath, FileMode.Create));
                    }

                }
                Employee newEmp = new Employee
                {
                    Name = emp.Name,
                    Email = emp.Email,
                    Department = emp.Department,
                    PhotoPath = uniqueFilename
                };
                try
                {
                    newEmp = _employeeRepository.Add(newEmp);
                }catch(Exception e)
                {
                    Response.Redirect("error.html");
                }
                return RedirectToAction("details", new { id = newEmp.Id });
            }
            else
            {
                //return RedirectToAction("create", emp);
                return View();
            }


        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            Employee employee = _employeeRepository.GetEmployee(id);
            EmpEditViewModel empEditViewModel = new EmpEditViewModel()
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                Department = employee.Department,
                ExistingPhotoPath = employee.PhotoPath
            };
            return View(empEditViewModel);
        }
    }
}
