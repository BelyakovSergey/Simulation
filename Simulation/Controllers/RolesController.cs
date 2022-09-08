using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Simulation.Models;

namespace Simulation.Controllers
{
    [ApiController]
    [Route("admin")]
    public class RolesController : ControllerBase
    {
        RoleManager<IdentityRole> _roleManager;
        UserManager<IdentityUser> _userManager;

        public RolesController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [HttpGet]
        [Route("getroles")]
        public List<IdentityRole> GetUsers()
        {
            return _roleManager.Roles.ToList();
        }

        [HttpPost]
        [Route("newrole")]
        public async Task<IdentityResult> CreateRole(string name)
        {
            return await _roleManager.CreateAsync(new IdentityRole(name));
        }
    }
}
