using ReportingProject.Data.Entities;

namespace ReportingProject.Repositories.ReportRepository
{
    public interface IReportRepository
    {
        Task<IEnumerable<Report>> GetAllReportsAsync();
        Task<Report> GetReportByIdAsync(int id);
        Task UploadReportAsync(Report entity);
        Task UpdateReportAsync(Report entity);
        Task DeleteReportAsync(int id);
    }
}
