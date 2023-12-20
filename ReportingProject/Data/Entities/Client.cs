namespace ReportingProject.Data.Entities
{
    public class Client
    {
        public int ID { get; set; }
        public int? CompanyId { get; set; }
        public int ClientRef { get; set; }
        public bool IsBlackListed { get; set; }
        public int InvoiceBillingPeriod { get; set; } = 60;
        public List<FinancialAccount>? FinancialAccount { get; set; }
        public Company? Company { get; set; }
        public Consultant? Consultant { get; set; }

    }
}
