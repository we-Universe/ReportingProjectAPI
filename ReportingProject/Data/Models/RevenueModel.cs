namespace ReportingProject.Data.Models
{
	public class RevenueModel
	{
        public int? ServiceId { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int TotalSubscriptions { get; set; }
        public int PostSubscriptions { get; set; }
        public decimal Refund { get; set; }
    }
}