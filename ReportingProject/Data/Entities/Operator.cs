namespace ReportingProject.Data.Entities
{
    public class Operator
    {
        public int Id { get; set; }
        public int Prefix { get; set; }
        public int? CompanyId { get; set; }
        public int MSISDNLength { get; set; }
        public  decimal VatValue { get; set; }
        public  decimal PNAValue { get; set; }
        public decimal BadDept { get; set; }
        public decimal NonResidentialValue { get; set; }
        public int InvoiceBillingPeriod { get; set; }
        public List<UniverseInvoice>? UniverseInvoices { get; set; }
        public Company? Company { get; set; }
        public List<OperatorReport>? OperatorReports { get; set; }
        public List<ServiceOperator>? ServiceOperators { get; set; }

    }
}