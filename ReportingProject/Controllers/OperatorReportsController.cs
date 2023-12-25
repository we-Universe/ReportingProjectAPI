using Microsoft.AspNetCore.Mvc;
using ReportingProject.Data.Models;
using ReportingProject.Services.OperatorReportService;
using ReportingProject.Services.ReportService;

namespace ReportingProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperatorReportsController : ControllerBase
    {
        private readonly IOperatorReportService _OperatorReportService;
        //private readonly IReportService _reportService;

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

        //[HttpPost("AddOperatorReport")]
        //public async Task<IActionResult> CreateOperatorReport([FromBody] ReportModel operatorReportsModel)
        //{
        //    try
        //    {
        //        await _OperatorReportService.UploadOperatorReportAsync(operatorReportsModel);

        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.Error.WriteLine(ex.Message);
        //        return StatusCode(500, "Internal Server Error");
        //    }
        //}
    }
}