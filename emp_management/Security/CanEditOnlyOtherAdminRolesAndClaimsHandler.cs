using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace emp_management.Security
{
    public class CanEditOnlyOtherAdminRolesAndClaimsHandler : AuthorizationHandler<ManageAdminRolesAndClaimsRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ManageAdminRolesAndClaimsRequirement requirement)
        {
            //throw new NotImplementedException();
            var authFilterContext = context.Resource as AuthorizationFilterContext;
            if(authFilterContext == null)
            {
                return Task.CompletedTask;
            }
            string LoggedInAdminId =
                context.User.Claims.FirstOrDefault(s => s.Type == ClaimTypes.NameIdentifier).Value;
            string AdminIdBeingEdited =
                authFilterContext.HttpContext.Request.Query["userId"];
            if(context.User.IsInRole("Admin") && 
                context.User.HasClaim(claim => claim.Type == "Edit Role" && claim.Value == "true") && 
                AdminIdBeingEdited.ToLower() != LoggedInAdminId.ToLower())
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
