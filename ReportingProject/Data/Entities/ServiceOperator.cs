using System.ComponentModel.DataAnnotations.Schema;

namespace ReportingProject.Data.Entities
{
    public class ServiceOperator
    {
        public int? ServiceId { get; set; }
        public int? OperatorId { get; set; }
        public int MWRef { get; set; }
        public int? ShortCode { get; set; }
        public int? ServiceStatusId { get; set; }
        public decimal OperatorShare { get; set; }
        public decimal PostPrice { get; set; }
        public decimal PrePrice { get; set; }
        public DateTime LaunchDate { get; set; }
        public byte[]? MTITFile { get; set; }
        public Service? Service { get; set; }
        public Operator? Operator { get; set; }
        public ServiceStatus? ServiceStatus { get; set; }
    }
}
