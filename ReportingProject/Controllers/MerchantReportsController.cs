﻿using Microsoft.AspNetCore.Mvc;
using ReportingProject.Services.MerchantReportService;

namespace ReportingProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MerchantReportsController : ControllerBase
    {
        private readonly IMerchantReportService _merchantReportService;

        public MerchantReportsController(IMerchantReportService merchantReportService)
        {
            _merchantReportService = merchantReportService;
        }

        [HttpGet("GetAllMerchantsReports")]
        public async Task<IActionResult> GetAllMerchantsReports()
        {
            var merchantReports = await _merchantReportService.GetAllMerchantsReportsAsync();
            return Ok(merchantReports);
        }

        [HttpGet("GenerateMerchantsReports")]
        public async Task <IActionResult> GenerateMerchantsReports()
        {
            await _merchantReportService.GenerateMerchantsReportsAsync();
            return Ok();
        }
    }
}