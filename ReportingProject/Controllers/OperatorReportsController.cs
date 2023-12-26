using Microsoft.AspNetCore.Mvc;
using ReportingProject.Services.OperatorReportService;

namespace ReportingProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperatorReportsController : ControllerBase
    {
        private readonly IOperatorReportService _OperatorReportService;
      

        public OperatorReportsController(IOperatorReportService operatorReportService)
        {
            _OperatorReportService = operatorReportService;
        }
        
        [HttpGet("GetAllOperatorReports")]
        public async Task<IActionResult> GetAllOperatorReports()
        {
            var reports = await _OperatorReportService.GetAllReportsAsync();
            return Ok(reports);
        }
    }
}