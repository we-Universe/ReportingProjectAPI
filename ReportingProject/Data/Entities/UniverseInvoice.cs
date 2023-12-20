namespace ReportingProject.Data.Entities
{
    public class UniverseInvoice
    {
        public int Id { get; set; }
        public int? OperatorId { get; set; }
        public int? InvoiceId { get; set; }
        public DateTime DueDate { get; set; }
        public Operator? Operator { get; set; }
        public Invoice? Invoice { get; set; }
    }
}
