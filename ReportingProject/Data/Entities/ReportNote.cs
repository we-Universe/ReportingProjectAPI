namespace ReportingProject.Data.Entities
{
    public class ReportNote
    {
        public int Id { get; set; }
        public int? ReportId { get; set; }
        public string Content { get; set; } = string.Empty;
        public Report? Report { get; set; }
    }
}