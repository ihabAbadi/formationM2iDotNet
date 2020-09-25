using Ecommerce.Models;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Tools
{
    public class RoleRequirement : IAuthorizationRequirement
    {
        public Erole Role { get; set; }

        public RoleRequirement()
        {

        }

        public RoleRequirement(Erole r)
        {
            Role = r;
        }
    }
}
