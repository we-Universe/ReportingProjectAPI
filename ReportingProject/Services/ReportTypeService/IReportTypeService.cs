using ReportingProject.Data.Entities;

namespace ReportingProject.Services.ReportTypeService
{
    public interface IReportTypeService
    {
        Task<IEnumerable<ReportType>> GetAllReportsTypesAsync();
        Task<ReportType> GetReportTypeByIdAsync(int id);
        Task AddReportTypeAsync(ReportType entity);
        Task UpdateReportTypeAsync(ReportType entity);
        Task DeleteReportTypeAsync(int id);
    }
}
