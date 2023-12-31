namespace ReportingProject.Data.Entities
{
    public class MerchantReport
    {
        public int Id { get; set; }
        public int? ReportId { get; set; }
        public int? MerchantId { get; set; }
        public Report? Report { get; set; }
        public Merchant? Merchant { get; set; }
    }
}