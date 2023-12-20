namespace ReportingProject.Data.Entities
{
    public class ServiceStatus
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<ServiceOperator>? ServiceOperators { get; set; } 
    }
}
