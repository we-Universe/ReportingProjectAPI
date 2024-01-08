using Microsoft.AspNetCore.Mvc;
using ReportingProject.Data.Models;
using ReportingProject.Services.ContractService;
using ReportingProject.Services.MerchantService;

namespace ReportingProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private readonly IContractService _contractService;
        private readonly IMerchantService _merchantService;

        public ContractController(IContractService contractService, IMerchantService merchantService)
        {
            _contractService = contractService;
            _merchantService = merchantService;
        }

        [HttpPost("AddContract")]
        public async Task<IActionResult> CreateContract([FromBody] ContractModel contractModel)
        {
            try
            {
                string employeeName = contractModel.MerchantName;

                int? merchantId = await _merchantService.GetMerchantIdByEmployeeNameAsync(employeeName);

                if (merchantId.HasValue)
                {
                    contractModel.MerchantId = merchantId;
                    await _contractService.UploadContractAsync(contractModel);

                    return Ok();
                }
                else
                {
                    return NotFound("Merchant not found for the provided employee name.");
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}