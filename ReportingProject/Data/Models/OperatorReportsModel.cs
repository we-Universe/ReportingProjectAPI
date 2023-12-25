namespace ReportingProject.Data.Models
{
	public class OperatorReportsModel 
    {
        public int ReportId { get; set; }

        public int OperatorId { get; set; }

        public byte[]? IMIFile { get; set; }

        public byte[]? DifferencesFile { get; set; }

        public byte[]? MWFile { get; set; }

        public byte[]? RefundFile { get; set; }
    }
}