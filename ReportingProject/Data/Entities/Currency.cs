namespace ReportingProject.Data.Entities
{
    public class Currency
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ISOCode { get; set; } = string.Empty;
        public List<Company>? Companies { get; set; }

    }
}
