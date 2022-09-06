using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Simulation.Models;

namespace Simulation.Controllers
{
    [ApiController]
    [Route("admin")]
    public class AdminController : ControllerBase
    {
        RoleManager<IdentityRole> _roleManager;
        UserManager<IdentityUser> _userManager;
        SignInManager<IdentityUser> _signInManager;
        
        public AdminController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        [Route("getusers")]
        public List<IdentityUser> GetUsers()
        {
            return _userManager.Users.ToList();
        }

        [HttpPost]
        [Route("newuser")]
        public async Task<IdentityResult> CreateUser(Client client)
        {
            var user = new IdentityUser { Email = client.Email, UserName = client.Name };
            return await _userManager.CreateAsync(user, client.Password);
        }

        [HttpPost]
        [Route("login")]
        public async Task<Microsoft.AspNetCore.Identity.SignInResult> Login(Client client)
        {
            return await _signInManager.PasswordSignInAsync(client.Name, client.Password, false, false);
        }
    }
}
