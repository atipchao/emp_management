using emp_management.Models;
using emp_management.ViewModes;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger logger;

        public HomeController(IEmployeeRepository employeeRepository, IHostingEnvironment hostingEnvironment, ILogger<HomeController> logger)
        {
            
            _employeeRepository = employeeRepository;
            _hostingEnvironment = hostingEnvironment;
            this.logger = logger;
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
            //throw new Exception("Error in details view");
            logger.LogTrace("Log Trace");
            logger.LogDebug("Log Debug");
            logger.LogInformation("Log Information");
            logger.LogWarning("Log Warning");
            logger.LogError("Log Error");
            logger.LogCritical("Log Critical");
            //logger.Logn
            Employee em = new Employee();

            em = _employeeRepository.GetEmployee(id ?? 1);

            if(em == null)
            {
                Response.StatusCode = 404;
                return View("EmployeeNotFound", id.Value);
            }
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

        [HttpPost]
        //public RedirectToActionResult Create(Employee emp)
        public ActionResult Edit(EmpEditViewModel emp)
        {
            // get the target emp
            
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
                try
                {


                    Employee targetEmp = _employeeRepository.GetEmployee(emp.Id);
                    targetEmp.Name = emp.Name;
                    targetEmp.Email = emp.Email;
                    targetEmp.Department = emp.Department;
                    if (uniqueFilename != null)
                    {
                        // remove old image..
                        if (emp.Photos != null)
                        {
                            string OldImagePath = Path.Combine(_hostingEnvironment.WebRootPath, "images", emp.ExistingPhotoPath);
                            // Delete file
                            System.IO.File.Delete(OldImagePath);
                        }
                            
                        targetEmp.PhotoPath = uniqueFilename;
                    }
                    _employeeRepository.Update(targetEmp);
                    
                    

                }
                catch (Exception e)
                {
                    Response.Redirect("error.html");
                }
                return RedirectToAction("details", new { id = emp.Id});
            }
            else
            {
                //return RedirectToAction("create", emp);
                return View();
            }
        }

        [HttpGet]
        public ViewResult Delete(int id)
        {
            //Get the selected Emp
            Employee employee = _employeeRepository.GetEmployee(id);
            HomeDetailsViewModel DeleteDetailsViewModel = new HomeDetailsViewModel()
            {
                Employee = employee,
                PageTitle = "Emp Delete Details"
            };
            return View(DeleteDetailsViewModel);
        }

        [HttpPost]
        public ViewResult Delete(Employee emp)
        {


            //return RedirectToAction("Index",null);
            EmpSuccessDeletedViewModel ret_empSuccessDeletedViewModel;
            try
            {
                Employee employee;
                employee = _employeeRepository.Delete(emp.Id);
                EmpSuccessDeletedViewModel empSuccessDeletedViewModel = new EmpSuccessDeletedViewModel()
                {
                    Employee = employee,
                    PageTitle = "Emp Delete Successed!"
                };
                ret_empSuccessDeletedViewModel = empSuccessDeletedViewModel;
            }
            catch
            {
                Response.StatusCode = 404;
                return View("FailDeleteEmployee", emp.Id);
            }

            return View("EmpSuccessDeleted", ret_empSuccessDeletedViewModel);
        }
    }
}
