using ReportingProject.Data.Entities;
using ReportingProject.Data.Resources;

namespace ReportingProject.Repositories.ReportRepository
{
    public interface IReportRepository
    {
        Task<IEnumerable<Report>> GetAllReportsAsync();
        Task<Report> GetReportByIdAsync(int id);
        Task UploadReportAsync(Report entity);
        Task UpdateReportAsync(Report entity);
        Task DeleteReportAsync(int id);
        Task<IEnumerable<Report>> GetReportByReportIdAsync(int reportId);
        Task<IEnumerable<ReportAndOperatorResource>> GetReportsByOperatorIdAsync();
        Task<IEnumerable<ReportAndOperatorAnotherFormatResource>> GetReportsByOperatorReportAsync();
        Task<IEnumerable<ReportAndMerchantResource>> GetReportsByMerchantReportAsync();
    }
}