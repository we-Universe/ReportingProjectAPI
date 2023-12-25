using Microsoft.AspNetCore.Mvc;
using ReportingProject.Data.Models;
using ReportingProject.Services.AuthenticationService;

namespace ReportingProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserAuthenticationService _userAuthenticationService;

        public AuthenticationController(IUserAuthenticationService userAuthenticationService)
        {
            _userAuthenticationService = userAuthenticationService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser(RegisterModel registerModel)
        {
            var errors = await _userAuthenticationService.RegisterUser(registerModel);
            
            if (errors != "")
            {
                return BadRequest(errors);    
            }
            return Ok("User registered successfuly");

        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (await _userAuthenticationService.Login(loginModel))
            {
                var accessData = _userAuthenticationService.GenerateToken(loginModel);
                return Ok(accessData);
            }
            return BadRequest("Invalid username or password !!");
        }

        [HttpPost("ForgetPassword")]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordModel forgetPasswordModel)
        {
            if (await _userAuthenticationService.ForgetPassword(forgetPasswordModel))
            {
                return Ok("A new password sent successfully, please check your email");

            }
                return BadRequest("An error occurred, please try later");
        }

        [HttpGet("GetAllRoles")]
        public IActionResult GetAllRoles()
        {
            var roles = _userAuthenticationService.GetAllRoles();
            if (roles.Count > 0)
            {
                return Ok(roles);

            }
            return NotFound("No roles found!");
        }


    }
}
