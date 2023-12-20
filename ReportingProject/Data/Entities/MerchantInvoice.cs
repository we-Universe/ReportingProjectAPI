namespace ReportingProject.Data.Entities
{
    public class MerchantInvoice
    {
        public int Id { get; set; }
        public int? InvoiceId { get; set; }
        public int? MerchantId { get; set; }
        public string Services { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public int? ApprovalStatusId { get; set; }
        public Invoice? Invoice { get;}
        public Merchant? Merchant { get;}
        public ApprovalStatus? ApprovalStatus { get; set; }  
    }
}
