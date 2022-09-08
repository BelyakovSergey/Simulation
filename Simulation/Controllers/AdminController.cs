using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Simulation.Models;

namespace Simulation.Controllers
{
    [ApiController]
    [Route("admin")]
    public class AdminController : ControllerBase
    {
        UserManager<IdentityUser> _userManager;
        SignInManager<IdentityUser> _signInManager;

        public AdminController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
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
            await _signInManager.SignInAsync(user, false);
            return await _userManager.CreateAsync(user, client.Password);
        }

        [HttpPost]
        [Route("login")]
        public async Task<Microsoft.AspNetCore.Identity.SignInResult> Login(Client client)
        {
            var result = await _signInManager.PasswordSignInAsync(client.Name, client.Password, false, false);
            if (result.Succeeded)
            {

            }
            return result;
        }

        //[HttpPost]
        //[Route("addroles")]
        //public async Task<IdentityResult> AddRoles(Client client)
        //{
        //    var user = new IdentityUser { Email = client.Email, UserName = client.Name };
        //    return await _userManager.AddToRolesAsync(user, new List<string> { "Admin" });
        //}
    }
}
