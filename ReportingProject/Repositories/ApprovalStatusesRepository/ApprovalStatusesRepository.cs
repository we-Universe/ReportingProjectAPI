using Microsoft.EntityFrameworkCore;
using ReportingProject.Data.Contextes;
using ReportingProject.Data.Entities;

namespace ReportingProject.Repositories.ApprovalStatusesRepository
{
    public class ApprovalStatusesRepository : IApprovalStatusesRepository
    {
        private readonly ReportingDBContext _reportingDBContext;
        private readonly DbSet<ApprovalStatus> _dbSet;

        public ApprovalStatusesRepository(ReportingDBContext reportingDBContex)
        {
            _reportingDBContext = reportingDBContex;
            _dbSet = _reportingDBContext.Set<ApprovalStatus>();
        }

        public async Task<IEnumerable<ApprovalStatus>> GetAllApprovalStatusesAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<string> GetApprovalStatusNameByApprovalStatusIdAsync(int approvalStatusId)
        {
            try
            {
                var approvalStatus = await _dbSet
                    .Where(approvalStatus => approvalStatus.Id == approvalStatusId)
                    .FirstOrDefaultAsync();

                if (approvalStatus == null)
                {
                    throw new Exception($"No approval status found for approvalStatusId: {approvalStatusId}");
                }

                return approvalStatus.Name;
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching approval status from the database.", ex);
            }
        }
    }
}