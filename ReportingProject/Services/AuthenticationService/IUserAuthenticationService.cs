using ReportingProject.Data.Models;
using ReportingProject.Data.Resources;

namespace ReportingProject.Services.AuthenticationService
{
    public interface IUserAuthenticationService
    {
        AccessDataResource GenerateToken(LoginModel loginModel);
        Task<bool> Login(LoginModel loginModel);
        Task<bool> RegisterUser(RegisterModel registerModel);
        Task<bool> ForgetPassword(ForgetPasswordModel forgetPasswordModel);
    }
}
