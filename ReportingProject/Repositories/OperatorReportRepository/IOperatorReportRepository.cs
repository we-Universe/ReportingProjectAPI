using ReportingProject.Data.Entities;

namespace ReportingProject.Repositories.OperatorReportRepository
{
	public interface IOperatorReportRepository
	{
        Task<IEnumerable<OperatorReport>> GetAllReportsAsync();
        Task<OperatorReport> GetReportByIdAsync(int id);
        Task UploadReportAsync(OperatorReport entity);
        Task UpdateReportAsync(OperatorReport entity);
        Task DeleteReportAsync(int id);
    }
}