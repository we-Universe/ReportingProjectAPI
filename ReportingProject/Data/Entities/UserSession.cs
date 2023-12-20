namespace ReportingProject.Data.Entities
{
    public class UserSession
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string UserAgent { get; set; } = string.Empty;
        public string UserHostName { get; set; } = string.Empty;
        public string UserHostAddress { get; set; } = string.Empty;
        public string MachineAddress { get; set; } = string.Empty;
        public ApplicationUser? ApplicationUser { get; set; }
    }

}
