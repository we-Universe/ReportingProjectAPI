namespace ReportingProject.Data.Entities
{
    public class InvoiceStatus
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Invoice>? Invoices { get; set; }
    }
}
