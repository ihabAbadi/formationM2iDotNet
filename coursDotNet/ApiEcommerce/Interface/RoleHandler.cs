using Ecommerce.Tools;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Ecommerce.Interface
{
    public class RoleHandler : AuthorizationHandler<RoleRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RoleRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == ClaimTypes.Email))
            {
                return Task.CompletedTask;
            }
            else
            {
                if (requirement.Role == null || (context.User.HasClaim(c => c.Type == ClaimTypes.Role) && context.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value == requirement.Role.Role))
                {
                    context.Succeed(requirement);
                }
                return Task.CompletedTask;
            }

        }
    }
}
