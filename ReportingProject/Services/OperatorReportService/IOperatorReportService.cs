using ReportingProject.Data.Entities;
using ReportingProject.Data.Models;
using ReportingProject.Data.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReportingProject.Services.OperatorReportService
{
    public interface IOperatorReportService
    {
        Task<IEnumerable<OperatorReportsResource>> GetAllReportsAsync();
        Task<OperatorReport> GetReportByIdAsync(int id);
        Task UploadReportAsync(OperatorReportsModel model);
        Task UpdateReportAsync(OperatorReport entity);
        Task DeleteReportAsync(int id);
    }
}