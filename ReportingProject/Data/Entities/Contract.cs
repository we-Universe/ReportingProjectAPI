namespace ReportingProject.Data.Entities
{
    public class Contract
    {
        public int Id { get; set; }
        public int? MerchantId { get; set; }
        public decimal ClientShare { get; set; }
        public byte[]? ContractFile { get; set; }
        public string Notes { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime TerminationDate { get; set; }
        public Merchant? Merchant { get; set; }
        public Service? Service { get; set; }
    }
}