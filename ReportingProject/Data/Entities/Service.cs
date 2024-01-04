using Microsoft.EntityFrameworkCore;

namespace ReportingProject.Data.Entities
{
    [Index(nameof(Name))]
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal ConsultantShare { get; set; }
        public int? ServiceTypeId { get; set; }
        public int? ContractId { get; set; }
        public int? IndustryTypeId { get; set; }
        public IndustryType? IndustryType { get; set; }
        public ServiceType? ServiceType { get; set; }
        public Contract? Contract { get; set; }
        public List<ServiceOperator> ServiceOperators { get; set; } = new List<ServiceOperator>();
        public List<Revenue>? Revenues { get; set; }
    }
}