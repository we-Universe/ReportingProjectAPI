using ReportingProject.Data.Entities;

namespace ReportingProject.Data.Models
{
	public class OperatorReportsModel : ReportModel
    {
        //foreign key
        public int ReportId { get; set; }
        public Report? Report { get; set; }

        //foreign key
        public int OperatorId { get; set; }
        public Operator? Operator { get; set; }

        public byte[]? IMIFile { get; set; }

        public byte[]? DifferencesFile { get; set; }

        public byte[]? MWFile { get; set; }

        public byte[]? RefundFile { get; set; }
    }
}