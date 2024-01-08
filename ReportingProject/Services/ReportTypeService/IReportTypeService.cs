using ReportingProject.Data.Entities;
using ReportingProject.Data.Resources;

namespace ReportingProject.Services.ReportTypeService
{
    public interface IReportTypeService
    {
        Task<IEnumerable<ReportTypeResource>> GetAllReportsTypesAsync();
        Task<ReportType> GetReportTypeByIdAsync(int id);
        Task AddReportTypeAsync(ReportType entity);
        Task UpdateReportTypeAsync(ReportType entity);
        Task DeleteReportTypeAsync(int id);
        Task<int> GetReportTypeIdFromNameAsync(string name);
        Task<IEnumerable<string>> GetAllReportTypeNamesAsync();
    }
}
