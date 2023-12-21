using ReportingProject.Data.Entities;

namespace ReportingProject.Services.ReportService
{
    public interface IReportService
    {
        Task<IEnumerable<Report>> GetAllReportsAsync();
        Task<Report> GetReportByIdAsync(int id);
        Task UploadReportAsync(Report entity);
        Task UpdateReportAsync(Report entity);
        Task DeleteReportAsync(int id);
    }
}
