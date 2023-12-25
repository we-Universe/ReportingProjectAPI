namespace ReportingProject.Data.Resources
{
    public class OperatorReportsResource
    {
        public int Id { get; set; }
        public int? ReportId { get; set; }
        public int? OperatorId { get; set; }
        public byte[]? DifferencesFile { get; set; }
        public byte[]? MWFile { get; set; }
        public byte[]? IMIFile { get; set; }
        public byte[]? RefundFile { get; set; }
    }
}