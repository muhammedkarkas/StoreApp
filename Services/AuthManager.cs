using Microsoft.AspNetCore.Identity;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AuthManager : IAuthService
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthManager(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IEnumerable<IdentityRole> Roles => _roleManager.Roles;
    }
}
