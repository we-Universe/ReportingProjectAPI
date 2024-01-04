using ReportingProject.Data.Resources;

namespace ReportingProject.Services.ApprovalStatusesService
{
    public interface IApprovalStatusesService
    {
        Task<IEnumerable<ApprovalStatusesResource>> GetAllApprovalStatusesAsync();
        Task<string> GetAllApprovalStatusesByIdAsync(int approvalStatusid);
    }
}