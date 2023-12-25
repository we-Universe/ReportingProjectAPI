using ReportingProject.Data.Entities;

namespace ReportingProject.Data.Resources
{
    public class ReportResource
    {
        public int Id { get; set; }
        public int? ReportTypeId { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public DateTime LastModified { get; set; }
        public string Notes { get; set; } = string.Empty;
        public required byte[] ReportFile { get; set; }
        public int ApprovalStatusId { get; set; }
        public List<ReportNoteResource>? ReportNotes { get; set; }
    }
}