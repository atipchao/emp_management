using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace emp_management.Security
{
    public class SuperAdminHandler : AuthorizationHandler<ManageAdminRolesAndClaimsRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ManageAdminRolesAndClaimsRequirement requirement)
        {
            //throw new NotImplementedException();
            if(context.User.IsInRole("Super Admin"))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
