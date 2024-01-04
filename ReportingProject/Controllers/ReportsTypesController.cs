
using Microsoft.AspNetCore.Mvc;
using ReportingProject.Services.ReportTypeService;

namespace ReportingProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsTypesController : ControllerBase
    {
        private readonly IReportTypeService _reportTypeService;

        public ReportsTypesController(IReportTypeService reportTypeService)
        {
            _reportTypeService = reportTypeService;
        }

        [HttpGet("GetAllReportsTypes")]
        public async Task<IActionResult> GetAllReportsTypes()
        {
            var reportsTypes = await _reportTypeService.GetAllReportsTypesAsync();
            return Ok(reportsTypes);
        }

        [HttpGet("GetReportTypeIdFromName")]
        public async Task<IActionResult> GetReportTypeIdFromName(string name)
        {
            var reportsTypes = await _reportTypeService.GetReportTypeIdFromNameAsync(name);
            return Ok(reportsTypes);
        }
    }
}