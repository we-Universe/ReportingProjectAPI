using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using MimeKit;
using MimeKit.Text;
using PasswordGenerator;
using ReportingProject.Data.Entities;
using ReportingProject.Data.Models;
using ReportingProject.Data.Resources;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ReportingProject.Services.AuthenticationService
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _config;

        public UserAuthenticationService(UserManager<ApplicationUser> userManager, IConfiguration config, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _config = config;
            _roleManager = roleManager;
        }

        public async Task<bool> Login(LoginModel loginModel)
        {
            var applicationUser = await _userManager.FindByNameAsync(loginModel.Username);

            if (applicationUser is null)
            {
                return false;
            }

            return await _userManager.CheckPasswordAsync(applicationUser, loginModel.Password);
        }

        public async Task<string> RegisterUser(RegisterModel registerModel)
        {
            var errorMessage = "";
            var applicationUser = new ApplicationUser
            {
                UserName = registerModel.Username,
                Email = registerModel.Email,
                PhoneNumber = registerModel.PhoneNumber,
                CountryID = registerModel.CountryId,
                IsActive = registerModel.IsActive,
            };
            try
            {
                var applicationUserCreationResult = await _userManager.CreateAsync(applicationUser, registerModel.Password);

                if (!applicationUserCreationResult.Succeeded)
                {
                    errorMessage = applicationUserCreationResult.Errors.First().Description;
                    return errorMessage;
                }
                var addToRoleResult = await _userManager.AddToRoleAsync(applicationUser, registerModel.Role);

                if (!addToRoleResult.Succeeded)
                {
                    errorMessage = addToRoleResult.Errors.First().Description;
                    return errorMessage;
                 }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return errorMessage;
            }
            return errorMessage;
        }


        public AccessDataResource GenerateToken(LoginModel loginModel)
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

            var accessData = new AccessDataResource
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(securityToken),
                UserRole = userRoles.FirstOrDefault() ?? ""
            };

            return accessData;
        }

        public async Task<bool> ForgetPassword(ForgetPasswordModel forgetPasswordModel)
        {
            var user = await _userManager.FindByEmailAsync(forgetPasswordModel.Email);
            if (user == null || user.Email == null)
            {
                return false;
            }
            try
            {
                //Generate a new password
                var pwd = new Password(8).IncludeLowercase().IncludeUppercase().IncludeSpecial().IncludeNumeric();
                var generatedPassword = pwd.Next();

                // Update the user's password
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var result = await _userManager.ResetPasswordAsync(user, token, generatedPassword);

                if (!result.Succeeded)
                {
                    return false;
                }

                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse("example@we-universe.com"));
                email.To.Add(MailboxAddress.Parse(user.Email));
                email.Subject = "Forget Password";
                email.Body = new TextPart(TextFormat.Html) { Text ="Your new password: " + generatedPassword };

                using var smtp = new SmtpClient();
                smtp.Connect("smtp.office365.com", 587, SecureSocketOptions.StartTls);
                smtp.Authenticate("example@we-universe.com", "Password");
                smtp.Send(email);
                smtp.Disconnect(true);
                smtp.Dispose();
            }

            catch (Exception)
            {
                return false;
            }


            return true;
        }

        public List<IdentityRole> GetAllRoles()
        {
            var roles = _roleManager.Roles.ToList();
            return roles;
        }
    }
}
