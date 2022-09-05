using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Simulation.Data;

namespace Simulation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        RoleManager<IdentityRole> _roleManager;
        UserManager<IdentityUser> _userManager;
        public AdminController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [HttpGet]
        public List<IdentityRole> GetRoles()
        {
            return _roleManager.Roles.ToList();
        }

        [HttpGet]
        public List<IdentityUser> GetUsers()
        {
            return _userManager.Users.ToList();
        }
    }
}
