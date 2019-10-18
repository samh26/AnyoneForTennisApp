using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using AnyoneForTennisApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnyoneForTennisApp.Authorization
{
    public class CoachAuthorizationHandler : AuthorizationHandler<CoachAccessRequirement, Coach>
    {
        UserManager<IdentityUser> _userManager;

        public CoachAuthorizationHandler(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CoachAccessRequirement requirement, Coach resource)
        {
            if ((resource.Id.Equals(_userManager.GetUserId(context.User))) || context.User.IsInRole("Admin"))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }

    public class CoachAccessRequirement : IAuthorizationRequirement { }
}





