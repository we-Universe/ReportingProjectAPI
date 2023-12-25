using Microsoft.AspNetCore.Mvc;
using ReportingProject.Data.Models;
using ReportingProject.Services.OperatorReportService;

namespace ReportingProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperatorReportsController : ControllerBase
    {
        private readonly IOperatorReportService _reportService;

        public OperatorReportsController(IOperatorReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("GetAllOperatorReports")]
        public async Task<IActionResult> GetAllOperatorReports()
        {
            var reports = await _reportService.GetAllReportsAsync();
            return Ok(reports);
        }

        [HttpPost("AddOperatorReport")]
        public async Task<IActionResult> CreateOperatorReport([FromBody] OperatorReportsModel operatorReportsModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                //int reportId = await _reportsService.UploadReportAsync(operatorReportsModel);
                Console.WriteLine(operatorReportsModel);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}