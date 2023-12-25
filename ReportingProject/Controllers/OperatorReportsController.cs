using Microsoft.AspNetCore.Mvc;
using ReportingProject.Data.Entities;
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

                // Use AutoMapper to map OperatorReportsModel to OperatorReport
                //var operatorReport = _mapper.Map<OperatorReport>(operatorReportsModel);

                // Call the service method to add the record
                //await _reportService.UploadReportAsync(operatorReport);

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