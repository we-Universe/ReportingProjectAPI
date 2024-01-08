using ReportingProject.Data.Entities;

namespace ReportingProject.Data.Resources
{
    public class MerchantReportExcelResource
    {
        public Merchant? Merchant { get; set; }
        public Contract? Contract { get; set; }
        public Service? Service { get; set; }
        public ServiceType? ServiceType { get; set; }
        public ServiceOperator? ServiceOperator { get; set; }
        public Revenue? Revenue { get; set; }
        public Operator? Operator { get; set; }
        public Company? Company { get; set; }
        public Currency? Currency { get; set; }
        public Client? Client { get; set; }
        public Country? Country { get; set; }
    }
}
