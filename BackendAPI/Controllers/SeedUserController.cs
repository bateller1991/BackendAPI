using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using BackendAPI.Data;

namespace BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedUserController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;

        public SeedUserController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager,
            IConfiguration configuration, ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _context = context;
        }

        public class CreateUserModel
        {
            public string UserName { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
        }

        [HttpPost("Users")]
        public async Task<IActionResult> ImportUsers([FromBody] CreateUserModel newUser)
        {
            const string roleUser = "RegisteredUser";
            const string roleAdmin = "Administrator";

            if (await _roleManager.FindByNameAsync(roleUser) is null)
            {
                await _roleManager.CreateAsync(new IdentityRole(roleUser));
            }
            if (await _roleManager.FindByNameAsync(roleAdmin) is null)
            {
                await _roleManager.CreateAsync(new IdentityRole(roleAdmin));
            }

            var user = new IdentityUser
            {
                UserName = newUser.UserName,
                Email = newUser.Email,
            };

            var result = await _userManager.CreateAsync(user, newUser.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, roleUser);
                await _context.SaveChangesAsync();

                return Ok(new
                {
                    Message = "User added successfully",
                    User = user
                });
            }

            return BadRequest(result.Errors);
        }
    }
}
