using AutoMapper;
using ClosedXML.Excel;
using ReportingProject.Data.Resources;
using ReportingProject.Repositories.MerchantReportRepository;

namespace ReportingProject.Services.MerchantReportService
{
    public class MerchantReportService : IMerchantReportService
    {
        private readonly IMerchantReportRepository _merchantReportRepository;
        private readonly IMapper _mapper;

        public MerchantReportService(IMerchantReportRepository merchantReportRepository, IMapper mapper)
        {
            _merchantReportRepository = merchantReportRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MerchantReportResource>> GetAllMerchantsReportsAsync()
        {
            var merchantReports = await _merchantReportRepository.GetAllMerchantsReports();
            return _mapper.Map<IEnumerable<MerchantReportResource>>(merchantReports);
        }

        public void GenerateMerchantsReportsAsync()
        {
            string errors = "";
            string filePath = @"C:\Khaled\ReportsTemplates\UT_Pull_Report_Template.xlsx";

            try
            {

                using (var workbook = new XLWorkbook(filePath))
                {
                    var pullWorksheet = workbook.Worksheet("UTPullReportTemplate");
                    var pushWorksheet = workbook.Worksheet("UTPushReportTemplate");

                    var cellValue = pullWorksheet.Cell("A13").Value;
                    var cellValue2 = pushWorksheet.Cell("A13").Value;
                    Console.WriteLine($"Value in cell A1: {cellValue}");
                    Console.WriteLine($"Value in cell A1: {cellValue2}");
                }
            }
            catch (Exception ex)
            {
                errors = ex.Message;

            }
        }
    }
}
