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
        public async Task<IActionResult> CreateRevenue([FromForm] RevenueReportModel revenueModel)
        {
            try
            {
                await _revenueService.ProcessExcelFile(revenueModel.RevenueFile, revenueModel.Month, revenueModel.Year);
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