namespace ReportingProject.Data.Entities
{
    public class NotificationType
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public List<Notification>? Notifications { get; set; }
    }
}
