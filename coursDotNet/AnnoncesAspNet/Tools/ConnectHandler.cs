using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AnnoncesAspNet.Tools
{
    public class ConnectHandler : AuthorizationHandler<ConnectRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ConnectRequirement requirement)
        {
            
            if(!context.User.HasClaim(c => c.Type == ClaimTypes.Email))
            {
                return Task.CompletedTask;
            }
            else
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            } 
            
        }
    }
}
