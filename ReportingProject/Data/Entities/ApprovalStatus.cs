namespace ReportingProject.Data.Entities
{
    public class ApprovalStatus
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Report>? Reports { get; }
        public List<MerchantInvoice>? MerchantInvoices { get; }
    }
}