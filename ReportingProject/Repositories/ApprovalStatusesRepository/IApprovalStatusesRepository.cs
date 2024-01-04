using ReportingProject.Data.Entities;

namespace ReportingProject.Repositories.ApprovalStatusesRepository
{
    public interface IApprovalStatusesRepository
    {
        Task<IEnumerable<ApprovalStatus>> GetAllApprovalStatusesAsync();
        Task<string> GetApprovalStatusNameByApprovalStatusIdAsync(int approvalStatusId);
    }
}