using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReportingProject.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        
        public DateTime LastLoginDate { get; set; }
        public bool IsActive { get; set; }
        public Country? Country { get; set; }
        public List<Notification>? SentNotifications { get; set; }
        public List<Notification>? ReceivedNotifications { get; set; }
        public List<UserSession>? UserSessions { get; set; }

    }
}
