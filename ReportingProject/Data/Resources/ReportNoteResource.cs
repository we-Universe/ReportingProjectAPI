namespace ReportingProject.Data.Resources
{
    public class ReportNoteResource
    {
        public int Id { get; set; }
        public int? ReportId { get; set; }
        public string Content { get; set; } = string.Empty;
    }
}
