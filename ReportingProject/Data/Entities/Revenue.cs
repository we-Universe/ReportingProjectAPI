using Microsoft.EntityFrameworkCore;

namespace ReportingProject.Data.Entities
{
    [Index(nameof(Month), nameof(Year))]
    public class Revenue
    {
        public int Id { get; set; }
        public int? ServiceId { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int TotalSubscriptions { get; set; }
        public int PostSubscriptions { get; set; }
        public decimal Refund { get; set; }
        public decimal MerchantRevenue { get; set; }
        public decimal UniverseRevenue { get; set; }
        public Service? Service { get; set; }
    }

}
