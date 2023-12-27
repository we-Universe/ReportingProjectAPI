using Microsoft.AspNetCore.Mvc;
using ReportingProject.Services.OperatorService;

namespace ReportingProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperatorController : ControllerBase
    {
        private readonly IOperatorService _operatorService;

        public OperatorController(IOperatorService operatorService)
        {
            _operatorService = operatorService;
        }

        [HttpGet("GetOperatorIdByCompanyName")]
        public async Task<IActionResult> GetOperatorIdByCompanyName(string name)
        {
            var operatoriId = await _operatorService.GetOperatorIdByCompanyNameAsync(name);
            return Ok(operatoriId);
        }
    }
}