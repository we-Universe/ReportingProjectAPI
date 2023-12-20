namespace ReportingProject.Data.Entities
{
    public class Merchant
    {
        public int Id { get; set; }
        public int? IndustryTypeId { get; set; }
        public IndustryType? IndustryType { get; set; }
        public int? EmloyeeId { get; set; }
        public Employee? Employee { get; set; }
        public int? ConsultantId { get; set; }
        public Consultant? Consultant { get; set; }
        public List<MerchantReport>? MerchantReports { get; set;}
        public List<MerchantInvoice>? MerchantInvoices { get; set; }
        public List<Contract>? Contracts { get; set; }
    }
}
