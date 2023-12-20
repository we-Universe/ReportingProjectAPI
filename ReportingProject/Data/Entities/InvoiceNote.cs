namespace ReportingProject.Data.Entities
{
    public class InvoiceNote
    {
        public int Id { get; set; }
        public int? InvoiceId { get; set; }
        public string Content { get; set; } = string.Empty;
        public Invoice? Invoice { get; set; }
    }
}
