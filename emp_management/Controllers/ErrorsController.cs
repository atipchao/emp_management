using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace emp_management.Controllers
{
    public class ErrorsController : Controller
    {
        private readonly ILogger<ErrorsController> logger;

        public ErrorsController(ILogger<ErrorsController> logger)
        {
            this.logger = logger;
        }

        [Route("Errors/{StatusCode}")]
        public IActionResult HttpStatusCodeHandler(int StatusCode)
        {
            var statusCodeResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            switch (StatusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "The resource requested not found!";
                    logger.LogWarning($"404 error occured, Path: {statusCodeResult.OriginalPath}" 
                        + $" and QueryString: {statusCodeResult.OriginalQueryString}");
                    //ViewBag.Path = statusCodeResult.OriginalPath;
                    //ViewBag.QS= statusCodeResult.OriginalQueryString;
                    break;
            }
            return View("NotFound");
        }

        [Route("Errors")]
        [AllowAnonymous]
        public IActionResult Error()
        {
            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            //ViewBag.ExceptionPath = exceptionDetails.Path;
            //ViewBag.ExceptionMessage = exceptionDetails.Error.Message;
            //ViewBag.StackTrace = exceptionDetails.Error.StackTrace;
            logger.LogError($"The Path: {exceptionDetails.Path} threw an exception: {exceptionDetails.Error.Message}");
            return View("Error");

        }

    }
}
