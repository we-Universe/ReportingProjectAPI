using ReportingProject.Data.Entities;
using ReportingProject.Data.Resources;

namespace ReportingProject.Services.ReportService
{
    public interface IReportService 
    {
        Task<IEnumerable<ReportResource>> GetAllReportsAsync();
        Task<Report> GetReportByIdAsync(int id);
        Task UploadReportAsync(Report entity);
        Task UpdateReportAsync(Report entity);
        Task DeleteReportAsync(int id);
    }
}
