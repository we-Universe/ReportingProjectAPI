using Microsoft.AspNetCore.Mvc;
using ReportingProject.Data.Models;
using ReportingProject.Services.RevenueService;

namespace ReportingProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RevenueController : ControllerBase
    {
        private readonly IRevenueService _revenueService;

        public RevenueController(IRevenueService revenueService)
        {
            _revenueService = revenueService;
        }

        [HttpPost("AddRevenue")]
        public async Task<IActionResult> CreateRevenue([FromBody] RevenueReportModel revenueModel)
        {
            try
            {
                string excelFilePath = "/Users/mayar/desktop/UT oct 2023 Jawwal report.xlsx";
                IFormFile iformFile = _revenueService.ConvertToIFormFile(excelFilePath);

                 _revenueService.ProcessExcelFile(iformFile);
                // await _revenueService.UploadRevenueAsync(revenueModel);
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