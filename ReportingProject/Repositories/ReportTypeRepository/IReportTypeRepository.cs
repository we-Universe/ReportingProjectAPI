using ReportingProject.Data.Entities;

namespace ReportingProject.Repositories.ReportTypeRepository
{
    public interface IReportTypeRepository
    {
        Task<IEnumerable<ReportType>> GetAllReportsTypesAsync();
        Task<ReportType> GetReportTypeByIdAsync(int id);
        Task AddReportTypeAsync(ReportType entity);
        Task UpdateReportTypeAsync(ReportType entity);
        Task DeleteReportTypeAsync(int id);
        Task<int> GetReportTypeIdFromNameAsync(string name);
    }
}