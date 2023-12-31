using ReportingProject.Data.Entities;
using ReportingProject.Data.Models;
using ReportingProject.Data.Resources;

namespace ReportingProject.Services.ReportService
{
    public interface IReportService 
    {
        Task<IEnumerable<ReportResource>> GetAllReportsAsync();
        Task<Report> GetReportByIdAsync(int id);
        Task<IEnumerable<ReportResource>> GetReportByReportIdAsync(int reportId);
        Task UploadReportAsync(ReportModel model);
        Task UpdateReportAsync(Report entity);
        Task DeleteReportAsync(int id);
        Task<IEnumerable<ReportAndOperatorResource>> GetReportByOperatorReportIdAsync();
        Task<IEnumerable<ReportAndOperatorAnotherFormatResource>> GetReportsByOperatorReportAsync();
        Task UpdateReportAsync(ReportModel model);
        Task<IEnumerable<ReportAndMerchantResource>> GetReportsByMerchantReportAsync();
    }
}
