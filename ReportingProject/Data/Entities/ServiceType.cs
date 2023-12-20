namespace ReportingProject.Data.Entities
{
    public class ServiceType
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Service>? Services { get; set; }
    }
}
