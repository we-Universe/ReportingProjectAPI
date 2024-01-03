namespace ReportingProject.Data.Entities
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int? ServiceTypeId { get; set; }
        public int? ContractId { get; set; }
        public ServiceType? ServiceType { get; set; }
        public Contract? Contract { get; set; }
        public List<ServiceOperator> ServiceOperators { get; set; } = new List<ServiceOperator>();
        public List<Revenue>? Revenues { get; set; }
    }
}