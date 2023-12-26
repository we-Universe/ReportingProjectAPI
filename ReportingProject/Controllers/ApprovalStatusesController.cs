using Microsoft.AspNetCore.Mvc;
using ReportingProject.Services.ApprovalStatusesService;

namespace ReportingProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApprovalStatusesController : ControllerBase
    {
        private readonly IApprovalStatusesService _approvalStatusesService;

        public ApprovalStatusesController(IApprovalStatusesService approvalStatusesService)
        {
            _approvalStatusesService = approvalStatusesService;
        }

        [HttpGet("GetAllApprovalStatuses")]
        public async Task<IActionResult> GetAllApprovalStatuses()
        {
            var approvalStatuses = await _approvalStatusesService.GetAllApprovalStatusesAsync();
            return Ok(approvalStatuses);
        }

        [HttpGet("GetApprovalStatusByApprovalStatusId")]
        public async Task<IActionResult> GetApprovalStatusByApprovalStatusId(int approvalStatusId)
        {
            var approvalStatuses = await _approvalStatusesService.GetAllApprovalStatusesByIdAsync(approvalStatusId);
            return Ok(approvalStatuses);
        }
    }
}
