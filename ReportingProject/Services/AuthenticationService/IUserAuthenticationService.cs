using ReportingProject.Data.Models;
using ReportingProject.Data.Resources;

namespace ReportingProject.Services.AuthenticationService
{
    public interface IUserAuthenticationService
    {
        AccessData GenerateToken(LoginModel loginModel);
        Task<bool> Login(LoginModel loginModel);
        Task<bool> RegisterUser(LoginModel loginModel);
        Task<bool> ForgetPassword(ForgetPasswordModel forgetPasswordModel);
    }
}
