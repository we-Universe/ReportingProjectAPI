namespace ReportingProject.Data.Entities
{
    public class Notification
    {
        public int Id { get; set; }
        public string? SenderId { get; set; } = string.Empty;
        public string? ReceiverId { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }
        public int? NotificationTypeId { get; set; }
        public bool IsRead { get; set; }
        public ApplicationUser? Sender { get; set; }
        public ApplicationUser? Receiver { get; set; }
        public NotificationType? NotificationType { get; set; }
    }
}
