using emp_management.Models;
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
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IHostingEnvironment _hostingEnvironment;

        public CustomerController(ICustomerRepository customerRepository, IHostingEnvironment hostingEnvironment)
        {
            _customerRepository = customerRepository;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            IEnumerable<Customer> customers;
            customers = _customerRepository.GetAllCustomer();
            return View(customers);
        }

        public ViewResult Details(int? id)
        {
            Customer cus = new Customer();

            cus = _customerRepository.GetCustomer(id ?? 1);
            CustomerDetailsViweModel CusDetailsViewModel = new CustomerDetailsViweModel()
            {

                customer = cus,
                PageTitle = "Cus Details"

            };

            return View(CusDetailsViewModel);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        //public RedirectToActionResult Create(Employee emp)
        public ActionResult Create(CusCreateViewModel cus)
        {
            if (ModelState.IsValid)
            {
                string uniqueFilename = null;
                if (cus.Photos != null && cus.Photos.Count > 0)
                {
                    foreach (IFormFile photo in cus.Photos)
                    {
                        string uploadFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                        uniqueFilename = Guid.NewGuid().ToString() + "_" + photo.FileName;
                        string filePath = Path.Combine(uploadFolder, uniqueFilename);
                        photo.CopyTo(new FileStream(filePath, FileMode.Create));
                    }

                }
                Customer newCus = new Customer
                {
                    Name = cus.Name,
                    Email = cus.Email,
                    MemberType = cus.membertype,
                    PhotoPath = uniqueFilename
                };
                try
                {
                    newCus = _customerRepository.Add(newCus);
                }
                catch (Exception e)
                {
                    Response.Redirect("error.html");
                }
                return RedirectToAction("details", new { id = newCus.Id });
            }
            else
            {
                //return RedirectToAction("create", emp);
                return View();
            }


        }

    }
}