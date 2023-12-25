using ReportingProject.Data.Entities;
using ReportingProject.Data.Resources;

namespace ReportingProject.Services.OperatorReportService
{
	public interface IOperatorReportService
	{
        Task<IEnumerable<OperatorReportsResource>> GetAllReportsAsync();
        Task<OperatorReport> GetReportByIdAsync(int id);
        Task UploadReportAsync(OperatorReport entity);
        Task UpdateReportAsync(OperatorReport entity);
        Task DeleteReportAsync(int id);
    }
}