using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Shared.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Server.Controllers
{
    [Route("api/(controller)")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IConfiguration configuration;

        public UserController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.configuration = configuration;
        }

        //.../api/user/register
        [Route("register")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            string username = user.EmailAdress;
            string password = user.Password;

            IdentityUser identityUser = new IdentityUser
            {
                Email = username,
                UserName = username
            };

            IdentityResult identityResult = await userManager.CreateAsync(identityUser, password);

            if (identityResult.Succeeded == true)
            {
                return Ok(new { identityResult.Succeeded });
            }
            else
            {
                string errorsToReturn = "register failed with the following errors";

                foreach (var error in identityResult.Errors)
                {
                    errorsToReturn += Environment.NewLine;
                    errorsToReturn += $"Error code: {error.Code} - {error.Description}";
                }
                return StatusCode(StatusCodes.Status500InternalServerError, errorsToReturn);
            }
        }
        [Route("signin")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> SignIn([FromBody] User user)
        {
            string username = user.EmailAdress;
            string password = user.Password;

            Microsoft.AspNetCore.Identity.SignInResult signInResult = await signInManager.PasswordSignInAsync(username, password, false, false);

            if (signInResult.Succeeded == true)
            {
                IdentityUser identityUser = await userManager.FindByNameAsync(username);
                string JSONWebTokenAsString = await GenerateJSONWebToken(identityUser);
                return Ok(JSONWebTokenAsString);
            }
            else
            {
                return Unauthorized(User);
            }
        }

        [NonAction]
        [ApiExplorerSettings(IgnoreApi = true)]
        private async Task<string> GenerateJSONWebToken(IdentityUser identityUser)
        {
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            SigningCredentials credentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            // claim = who is the person trying to sign in claiming to be?
            List<Claim> claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, identityUser.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, identityUser.Id)
            };
            IList<string> roleNames = await userManager.GetRolesAsync(identityUser);
            claims.AddRange(roleNames.Select(roleName => new Claim(ClaimsIdentity.DefaultRoleClaimType, roleName)));

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken
            (
                configuration["Jwt:Issuer"],
                configuration["Jwt:Issuer"],
                claims,
                null,
                expires: DateTime.UtcNow.AddDays(28),
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }
    }
}