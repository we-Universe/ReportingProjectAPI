namespace ReportingProject.Data.Models
{
    public class OperatorReportInput
    {
        public required OperatorReportsModel OperatorReportsModel { get; set; }
        public required ReportModel ReportModel { get; set; }
    }
}