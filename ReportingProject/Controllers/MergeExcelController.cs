using Microsoft.AspNetCore.Mvc;
using ReportingProject.Data.Models;
using ReportingProject.Services.ExcelService;
using ReportingProject.Services.InvoiceService;

namespace ReportingProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MergeExcelController :ControllerBase
    {
        private readonly IExcelService _excelService;

        public MergeExcelController(IExcelService excelService)
        {
            _excelService = excelService;
        }

        [HttpPost("merge")]
        public IActionResult MergeExcelFiles([FromForm] FileModel files)
        {
            try
            {
                var mergedFileModel = _excelService.MergeExcelFiles(files);
                return Ok(mergedFileModel);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

    }
}
