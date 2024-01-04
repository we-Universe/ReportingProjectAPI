namespace ReportingProject.Data.DTO
{
    public class ServiceData
    {
        public string PartnerName { get; set; } = string.Empty;
        public string ServiceShortCode { get; set; } = string.Empty;
        public string ServiceName { get; set; } = string.Empty;
        public double ServicePNA { get; set; }
        public double ServiceRevenueShare { get; set; }
        public double ServicePrePrice { get; set; }
        public double ServicePostPrice { get; set; }
        public double TotalDuration { get; set; }
        public double TotalCharge { get; set; }
        public double TotalPreCharge { get; set; }
        public double TotalPostCharge { get; set; }
        public double TotalRevenue { get; set; } 
    }
}
