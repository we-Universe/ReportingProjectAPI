using Microsoft.AspNetCore.Mvc;
using ReportingProject.Services.MerchantService;

namespace ReportingProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MerchantController : ControllerBase
    {
        private readonly IMerchantService _merchantService;

        public MerchantController(IMerchantService merchantService)
        {
            _merchantService = merchantService;
        }

        [HttpGet("GetAllMerchantNames")]
        public async Task<IActionResult> GetAllMerchantNames()
        {
            var merchantNames = await _merchantService.GetAllMerchantNamesAsync();
            return Ok(merchantNames);
        }
    }
}