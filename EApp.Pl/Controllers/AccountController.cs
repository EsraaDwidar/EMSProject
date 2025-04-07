using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WorkShop.DAL.Models;

namespace EApp.Pl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountController(UserManager<IdentityUser> userManager,RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
            _roleManager = roleManager;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterNewUser([FromBody]RegisterUser user, string role)
        {
                //IdentityResult result = await _userManager.CreateAsync(appUser, user.Password);
                //if (result.Succeeded)
                //{
                //    return Ok("Success");
                //}
                //else
                //{
                //    foreach (var item in result.Errors)
                //    {
                //        ModelState.AddModelError("", item.Description);
                //    }
                //}
                var userExist = await _userManager.FindByEmailAsync(user.Email);
                if (userExist!=null)
                {
                    return BadRequest("User already Exist");
                }
                IdentityUser appUser = new()
                {
                    Email = user.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = user.UserName
                };
                if (await _roleManager.RoleExistsAsync(role))
                {
                    var roleResult = await _userManager.CreateAsync(appUser, user.Password);
                    if(!roleResult.Succeeded)
                    {
                        return BadRequest("User failed to create");
                    }
                    await _userManager.AddToRoleAsync(appUser, role);
                return Ok("User created Successfully");
                }
            else
            {
                return BadRequest("The role doesn't exist");
            }

        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LoginUser login)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = await _userManager.FindByNameAsync(login.UserName);
                if (user != null)
                {
                    if (await _userManager.CheckPasswordAsync(user, login.Password))
                    {
                        var claims = new List<Claim>();
                        //claims.Add(new Claim("name", "value"));
                        claims.Add(new Claim(ClaimTypes.Name, user.UserName));
                        claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
                        //claims.Add(new Claim(ClaimTypes.Role, user.Role));
                        claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
                        var roles = await _userManager.GetRolesAsync(user);
                        foreach (var role in roles)
                        {
                            claims.Add(new Claim(ClaimTypes.Role, role.ToString()));
                        }
                        //signingCredentials
                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));
                        var sc = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                        var token = new JwtSecurityToken(
                            claims: claims,
                            issuer: _configuration["JWT:Issuer"],
                            audience: _configuration["JWT:Audience"],
                            expires: DateTime.Now.AddHours(3),
                            signingCredentials: sc
                            );
                        var _token = new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(token),
                            expiration = token.ValidTo,
                        };
                        return Ok(_token);
                    }
                    else
                    {
                        return Unauthorized();
                    }
                }
                else
                {
                    ModelState.AddModelError("", "User Name is invalid");
                }
            }
            return BadRequest(ModelState);

        }
    }
}
