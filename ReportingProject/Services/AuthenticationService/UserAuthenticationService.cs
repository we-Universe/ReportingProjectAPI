using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using ReportingProject.Data.Models;
using ReportingProject.Data.Resources;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ReportingProject.Services.AuthenticationService
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _config;

        public UserAuthenticationService(UserManager<IdentityUser> userManager, IConfiguration config, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _config = config;
            _roleManager = roleManager;
        }

        public async Task<bool> Login(LoginModel loginModel)
        {
            var identityUser = await _userManager.FindByNameAsync(loginModel.Username);

            if (identityUser is null)
            {
                return false;
            }

            return await _userManager.CheckPasswordAsync(identityUser, loginModel.Password);
        }

        public async Task<bool> RegisterUser(LoginModel loginModel)
        {
            var identityUser = new IdentityUser
            {
                UserName = loginModel.Username,
            };

            var result = await _userManager.CreateAsync(identityUser, loginModel.Password);

            if (result.Succeeded)
            {
                //Please change it !!!
                // If user creation is successful, add the user to the specified role
                var addToRoleResult = await _userManager.AddToRoleAsync(identityUser, "Admin");

                if (!addToRoleResult.Succeeded)
                {
                    // Handle the error (e.g., log it, return false, etc.)
                    return false;
                }
            }
            return result.Succeeded;
        }

        public AccessData GenerateToken(LoginModel loginModel)
        {
            var user = _userManager.FindByNameAsync(loginModel.Username).Result;

            var claims = new List<Claim>
            {
                new(ClaimTypes.Email,loginModel.Username),
            };

            var userRoles = _userManager.GetRolesAsync(user!).Result;
            foreach (var role in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("Jwt:Key").Value!));

            var signingCred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);

            var securityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                issuer: _config.GetSection("Jwt:Issuer").Value,
                audience: _config.GetSection("Jwt:Audience").Value,
                signingCredentials: signingCred);

            var accessData = new AccessData
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(securityToken),
                UserRole = userRoles.FirstOrDefault() ?? ""
            };

            return accessData;
        }

        public async Task<bool> ForgetPassword(ForgetPasswordModel forgetPasswordModel)
        {
            var userEmail = await _userManager.FindByEmailAsync(forgetPasswordModel.Email);
            if(userEmail?.Email == null)
            {
                return false;
            }

            return true;
        }
    }
}
