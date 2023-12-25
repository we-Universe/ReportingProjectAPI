using Microsoft.AspNetCore.Mvc;
using ReportingProject.Services.ReportService;

namespace ReportingProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportsController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("GetAllReports")]
        public async Task<IActionResult> GetAllReports()
        {
           var reports = await _reportService.GetAllReportsAsync();
            return Ok(reports);   
        }

    }
}