using Microsoft.AspNetCore.Mvc;
using ReportingProject.Data.Models;
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

        [HttpPost("AddReport")]
        public async Task<IActionResult> CreateReport([FromBody] ReportModel reportModel)
        {
            try
            {
                await _reportService.UploadReportAsync(reportModel);

                return Ok();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("GetReportByReportId")]
        public async Task<IActionResult> GetReportByReportId(int reportId)
        {
            var reports = await _reportService.GetReportByReportIdAsync(reportId);
            return Ok(reports);
        }

        [HttpGet("GetReportByOperatorReport")]
        public async Task<IActionResult> GetReportByOperatorReport()
        {
            var reports = await _reportService.GetReportByOperatorReportIdAsync();
            return Ok(reports);
        }

        [HttpGet("GetReportsByOperatorReport")]
        public async Task<IActionResult> GetReportsByOperatorReport()
        {
            var reports = await _reportService.GetReportsByOperatorReportAsync();
            return Ok(reports);
        }
    }
}