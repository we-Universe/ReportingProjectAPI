using Microsoft.AspNetCore.Mvc;
using ReportingProject.Data.Models;
using ReportingProject.Services.InvoiceService;

namespace ReportingProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController :ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpPost("AddInvoiceReport")]
        public async Task<IActionResult> AddInvoiceReport([FromBody] InvoiceModel invoiceModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _invoiceService.AddInvoiceReportAsync(invoiceModel))
            {
                return Ok("Invoice Report Added successfuly");
            }
            return BadRequest("Something went worng");
          
        }
    }
}
