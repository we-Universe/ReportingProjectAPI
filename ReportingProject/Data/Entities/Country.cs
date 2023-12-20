namespace ReportingProject.Data.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ISOCode { get; set; } = string.Empty;
        public List<Company>? Companies { get; set; }
        public List<FinancialAccount>? FinancialAccounts { get; set; }
        public List<ApplicationUser>? Users { get; set; }
    }
}
