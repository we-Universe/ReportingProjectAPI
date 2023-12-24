namespace ReportingProject.Data.Entities
{
    public class OperatorReport
    {
        public int Id { get; set; }
        public int? ReportId { get; set; }
        public int? OperatorId { get; set; }
        public byte[]? DifferencesFile { get; set; }
        public byte[]? MWFile { get; set; }
        public byte[]? IMIFile { get; set; }
        public byte[]? RefundFile { get; set; }
        public Report? Report { get; set; }
        public Operator? Operator { get; set; }
    }
}