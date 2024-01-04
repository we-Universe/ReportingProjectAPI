using AutoMapper;
using ReportingProject.Data.Resources;
using ReportingProject.Repositories.ApprovalStatusesRepository;

namespace ReportingProject.Services.ApprovalStatusesService
{
    public class ApprovalStatusesService : IApprovalStatusesService
    {
        private readonly IApprovalStatusesRepository _approvalStatusesRepository;
        private readonly IMapper _mapper;

        public ApprovalStatusesService(IApprovalStatusesRepository approvalStatusesRepository, IMapper mapper)
        {
            _approvalStatusesRepository = approvalStatusesRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ApprovalStatusesResource>> GetAllApprovalStatusesAsync()
        {
            var approvalStatusesEntities = await _approvalStatusesRepository.GetAllApprovalStatusesAsync();
            return _mapper.Map<IEnumerable<ApprovalStatusesResource>>(approvalStatusesEntities);
        }

        public async Task<string> GetAllApprovalStatusesByIdAsync(int approvalStatusid)
        {
            return await _approvalStatusesRepository.GetApprovalStatusNameByApprovalStatusIdAsync(approvalStatusid);
        }
    }
}