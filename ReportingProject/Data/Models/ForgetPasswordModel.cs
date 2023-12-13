using System.ComponentModel.DataAnnotations;

namespace ReportingProject.Data.Models
{
    public class ForgetPasswordModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}
