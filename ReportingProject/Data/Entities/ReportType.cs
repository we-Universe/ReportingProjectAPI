namespace ReportingProject.Data.Entities
{
    public class ReportType
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Report>? Reports { get; set; }
    }
}
