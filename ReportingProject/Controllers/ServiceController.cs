using Microsoft.AspNetCore.Mvc;
using ReportingProject.Services.ServiceService;

namespace ReportingProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
	{
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet("GetServiceIdFromServiceName")]
        public async Task<IActionResult> GetServiceIdFromServiceName(string name)
        {
            var serviveId = await _serviceService.GetServiceIdFromServiceNameAsync(name);
            return Ok(serviveId);
        }
    }
}