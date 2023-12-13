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
        public async Task<IActionResult> RegisterUser(LoginModel loginModel)
        {
            if (await _userAuthenticationService.RegisterUser(loginModel))
            {
                return Ok("User registered successfuly");
            }
            return BadRequest("Something went worng");
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
                return Ok("Invalid username or password !!");

            }
                return  BadRequest("Invalid username or password !!");
        }


    }
}
