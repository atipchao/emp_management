﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace emp_management.Controllers
{
    public class ErrorsController : Controller
    {
        [Route("Errors/{StatusCode}")]
        public IActionResult HttpStatusCodeHandler(int StatusCode)
        {
            var statusCodeResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            switch (StatusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "The resource requested not found!";
                    ViewBag.Path = statusCodeResult.OriginalPath;
                    ViewBag.QS= statusCodeResult.OriginalQueryString;
                    break;
            }
            return View("NotFound");
        }
    }
}
