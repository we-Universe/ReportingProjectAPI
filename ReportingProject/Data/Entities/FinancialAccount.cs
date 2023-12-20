namespace ReportingProject.Data.Entities
{
    public class FinancialAccount
    {
        public int ID { get; set; }
        public string IBAN { get; set; } = string.Empty;
        public string SWIFTCode { get; set; } = string.Empty;
        public string AccountHolderName { get; set; } = string.Empty;
        public string AccountNumber { get; set; } = string.Empty;
        public string BankName { get; set; } = string.Empty;
        public string Branch { get; set; } = string.Empty;
        public int? CountryId { get; set; }
        public int? ClientId { get; set; }
        public byte[]? AccountFile { get; set; }
        public byte[]? SOAFile { get; set; }
        public DateTime SOADate { get; set; }
        public bool IsApproved { get; set; }
        public Country? Country { get; set; }
        public Client? Client { get; set; }

    }
}
