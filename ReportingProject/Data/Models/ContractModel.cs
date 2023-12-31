namespace ReportingProject.Data.Models
{
	public class ContractModel
	{
        public int? MerchantId { get; set; }
        public string MerchantName { get; set; } = string.Empty;
        public decimal ClientShare { get; set; }
        public byte[]? ContractFile { get; set; }
        public string Notes { get; set; } = string.Empty;
        public DateTime Date { get; set; }
    }
}