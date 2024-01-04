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

        public async Task GenerateMerchantsReportsAsync()
        {
            string errors = "";
            string filePath = @"C:\Khaled\ReportsTemplates\ReportTemplates.xlsx";

            string folderPath = @"C:\Khaled\ReportsTemplates\NewExported\";
            string fileName = $"NewExcel_{DateTime.Now:yyyyMMddHHmmss}.xlsx";
            string newFilePath = Path.Combine(folderPath, fileName);

            try
            {
                var data = await _merchantReportRepository.GetDetailsDataForGeneratedMerchantReport(1,DateTime.Now.Month, DateTime.Now.Year);
                //Pull Service
                var pullDataDetails = data.Where(x => x?.ServiceType?.Id == 4);
                //Push Service
                var pushDataDetails = data.Where(x => x?.ServiceType?.Id == 3);

                using (var workbook = new XLWorkbook(filePath))
                {
                    var pullWorksheet = workbook.Worksheet("UTPullReportTemplate");
                    var pushWorksheet = workbook.Worksheet("UTPushReportTemplate");

                    using (var newWorkbook = new XLWorkbook())
                    {
                        if (pullDataDetails.Any())
                        {
                            ProcessGeneratedMerchantPullReport(pullWorksheet, pullDataDetails);

                            workbook.Worksheet("UTPullReportTemplate").CopyTo(newWorkbook,"Pull");

                        }

                        if (pushDataDetails.Any())
                        {
                            ProcessGeneratedMerchantPushReport(pushWorksheet, pushDataDetails);

                            workbook.Worksheet("UTPushReportTemplate").CopyTo(newWorkbook, "Push");

                        }

                        newWorkbook.SaveAs(newFilePath);

                    }

                }
            }
            catch (Exception ex)
            {
                errors = ex.Message;

            }
        }
        private static void ProcessGeneratedMerchantPullReport(IXLWorksheet pullWorksheet, IEnumerable<MerchantReportExcelResource> pullDataDetails)
        {
            int startRow = 16;
            decimal subTotal = 0.0m;
            var uniqueOperatorsNames = new HashSet<string>();

            foreach (var detail in pullDataDetails)
            {
                // Short Code Column
                pullWorksheet.Cell($"A{startRow}").Value = detail?.ServiceOperator?.ShortCode;

                // Code Name Column
                pullWorksheet.Cell($"B{startRow}").Value = detail?.Service?.Name;

                // Date Column
                pullWorksheet.Cell($"C{startRow}").Value = DateTime.Now.Date;

                // Operator Column
                pullWorksheet.Cell($"D{startRow}").Value = detail?.Company?.Name;

                // PNA Column
                pullWorksheet.Cell($"E{startRow}").Value = detail?.Operator?.PNAValue.ToString() + "%";

                // Bad Debt Column
                pullWorksheet.Cell($"F{startRow}").Value = detail?.Operator?.BadDept.ToString() + "%";

                // Revenue Sharing Column
                pullWorksheet.Cell($"G{startRow}").Value = (100 - detail?.ServiceOperator?.OperatorShare).ToString() + "%";

                //  Rate of SMS Column
                pullWorksheet.Cell($"H{startRow}").Value = detail?.ServiceOperator?.PostPrice.ToString();

                //  Number of post paid SMS Column
                pullWorksheet.Cell($"I{startRow}").Value = detail?.Revenue?.PostSubscriptions;
                pullWorksheet.Cell($"I{startRow}").Style.NumberFormat.Format = "0";

                //  Number of prepaid SMS Column
                pullWorksheet.Cell($"J{startRow}").Value = detail?.Revenue?.TotalSubscriptions - detail?.Revenue?.PostSubscriptions;

                //  Total Number of SMS Column
                pullWorksheet.Cell($"K{startRow}").Value = detail?.Revenue?.TotalSubscriptions;

                //  Net Total Revenue Column
                pullWorksheet.Cell($"L{startRow}").Value =
                    // Rate of SMS * Total number of SMS  
                    (detail?.ServiceOperator?.PostPrice * detail?.Revenue?.TotalSubscriptions);

                //  Client Share Column
                pullWorksheet.Cell($"M{startRow}").Value = detail?.Contract?.ClientShare.ToString() + "%";

                //  Client Net Share after  Column
                pullWorksheet.Cell($"N{startRow}").Value = detail?.Revenue?.MerchantRevenue.ToString();

                subTotal += detail?.Revenue?.MerchantRevenue ?? 0;
                uniqueOperatorsNames.Add(detail?.Company?.Name ?? "");
                startRow++;
            }
            var incomeTaxDeductions = pullDataDetails.First()?.Company?.Country?.Name != "Palestine" ? subTotal * -0.1m : 0.0m;
            var netRevenuesAfterDeductions = subTotal + incomeTaxDeductions;
            // Address
            pullWorksheet.Cell($"B3").Value = pullDataDetails.First()?.Company?.Address;
            // Client Reference
            pullWorksheet.Cell($"B4").Value = pullDataDetails.First()?.Company?.Client?.ClientRef;
            // Date
            pullWorksheet.Cell($"B5").Value = DateTime.Now.Date;
            // Currency
            pullWorksheet.Cell($"B6").Value = pullDataDetails.First()?.Currency?.ISOCode;
            // Operators
            pullWorksheet.Cell($"B7").Value = string.Join(", ", uniqueOperatorsNames); ;

            // Subtotal
            pullWorksheet.Cell($"N9").Value = subTotal.ToString();
            // Income Tax Deductions
            pullWorksheet.Cell($"N12").Value = incomeTaxDeductions.ToString();
            // Net Revenues After Deductions
            pullWorksheet.Cell($"N13").Value = netRevenuesAfterDeductions.ToString();


        }

        private static void ProcessGeneratedMerchantPushReport(IXLWorksheet pushWorksheet, IEnumerable<MerchantReportExcelResource> pushDataDetails)
        {
            int startRow = 16;
            decimal subTotal = 0.0m;
            var uniqueOperatorsNames = new HashSet<string>();

            foreach (var detail in pushDataDetails)
            {
                // Short Code Column
                pushWorksheet.Cell($"A{startRow}").Value = detail?.ServiceOperator?.ShortCode;

                // Code Name Column
                pushWorksheet.Cell($"B{startRow}").Value = detail?.Service?.Name;

                // Date Column
                pushWorksheet.Cell($"C{startRow}").Value = DateTime.Now.Date;

                // Operator Column
                pushWorksheet.Cell($"D{startRow}").Value = detail?.Company?.Name;

                // PNA Column
                pushWorksheet.Cell($"E{startRow}").Value = detail?.Operator?.PNAValue.ToString() + "%";

                // Bad Debt Column
                pushWorksheet.Cell($"F{startRow}").Value = detail?.Operator?.BadDept.ToString() + "%";

                // Revenue Sharing Column
                pushWorksheet.Cell($"G{startRow}").Value = (100 - detail?.ServiceOperator?.OperatorShare).ToString() + "%";

                // Post Paid Rate (Ex) Column
                pushWorksheet.Cell($"H{startRow}").Value = detail?.ServiceOperator?.PostPrice.ToString();

                // Pre Paid Rate (Inc) Column
                pushWorksheet.Cell($"I{startRow}").Value = detail?.ServiceOperator?.PrePrice.ToString();

                // Number of Post Paid Subscribers Column
                pushWorksheet.Cell($"J{startRow}").Value = detail?.Revenue?.PostSubscriptions;

                // Number of Pre Paid Subscribers Column
                pushWorksheet.Cell($"K{startRow}").Value = detail?.Revenue?.TotalSubscriptions - detail?.Revenue?.PostSubscriptions;

                // Total Subscriptions Column
                pushWorksheet.Cell($"L{startRow}").Value = detail?.Revenue?.TotalSubscriptions;

                //  Net Total Revenue Column
                pushWorksheet.Cell($"M{startRow}").Value =
                    (detail?.Revenue?.PostSubscriptions * detail?.ServiceOperator?.PostPrice) +
                    ((detail?.Revenue?.TotalSubscriptions - detail?.Revenue?.PostSubscriptions) * (detail?.ServiceOperator?.PrePrice/1.16m));

                //  Client Share Column
                pushWorksheet.Cell($"N{startRow}").Value = detail?.Contract?.ClientShare.ToString() + "%";

                //  Client Net Share after  Column
                pushWorksheet.Cell($"O{startRow}").Value = detail?.Revenue?.MerchantRevenue.ToString();

                subTotal += detail?.Revenue?.MerchantRevenue ?? 0;
                uniqueOperatorsNames.Add(detail?.Company?.Name ?? "");
                startRow++;
            }
            var incomeTaxDeductions = pushDataDetails.First()?.Company?.Country?.Name != "Palestine" ? subTotal * -0.1m : 0.0m;
            var netRevenuesAfterDeductions = subTotal + incomeTaxDeductions;
            // Address
            pushWorksheet.Cell($"B3").Value = pushDataDetails.First()?.Company?.Address;
            // Client Reference
            pushWorksheet.Cell($"B4").Value = pushDataDetails.First()?.Client?.ClientRef;
            // Date
            pushWorksheet.Cell($"B5").Value = DateTime.Now.Date;
            // Currency
            pushWorksheet.Cell($"B6").Value = pushDataDetails.First()?.Currency?.ISOCode;
            // Operators
            pushWorksheet.Cell($"B7").Value = string.Join(", ", uniqueOperatorsNames); ;

            // Subtotal
            pushWorksheet.Cell($"O9").Value = subTotal.ToString();
            // Income Tax Deductions
            pushWorksheet.Cell($"O12").Value = incomeTaxDeductions.ToString();
            // Net Revenues After Deductions
            pushWorksheet.Cell($"O13").Value = netRevenuesAfterDeductions.ToString();


        }
    }


}
