using Microsoft.EntityFrameworkCore;

namespace ReportingProject.Data.Entities
{
    [Index(nameof(Month), nameof(Year))]
    public class Report
    {
        public int Id { get; set; }
        public int? ReportTypeId { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public DateTime LastModified { get; set; }
        public required byte[] ReportFile { get; set; }
        public int ApprovalStatusId { get; set; }
        public ReportType? ReportType { get; set; }
        public ApprovalStatus? ApprovalStatus { get; set; }
        public OperatorReport? OperatorReport { get; set; }
        public MerchantReport? MerchantReport { get; set; }
        public List<ReportNote>? ReportNotes { get; set; }
    }
}
