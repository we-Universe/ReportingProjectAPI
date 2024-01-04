using ClosedXML.Excel;
using ReportingProject.Data.DTO;

namespace ReportingProject.Helpers.MergeExcelHelper
{
    public class MergeExcelHelper : IMergeExcelHelper
    {
       
            public void AddWorksheetFromExcelFile(XLWorkbook targetWorkbook, IFormFile file, string sheetname)
        {
            if (file != null && file.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    file.CopyTo(memoryStream);

                    using (var sourceWorkbook = new XLWorkbook(memoryStream))
                    {
                        var sourceWorksheet = sourceWorkbook.Worksheet(1);
                        var newWorksheet = targetWorkbook.Worksheets.Add(sheetname);

                        CopyWorksheetData(sourceWorksheet, newWorksheet);
                    }
                }
            }
        }

        public void CopyWorksheetData(IXLWorksheet sourceWorksheet, IXLWorksheet newWorksheet)
        {
            foreach (var sourceRow in sourceWorksheet.RowsUsed())
            {
                var newRow = newWorksheet.Row(sourceRow.RowNumber());

                foreach (var sourceCell in sourceRow.CellsUsed())
                {
                    newRow.Cell(sourceCell.Address.ColumnNumber).Value = sourceCell.Value;
                    newRow.Cell(sourceCell.Address.ColumnNumber).Style = sourceCell.Style;

                    if (sourceCell.IsMerged())
                    {
                        var sourceCellAddress = sourceCell.Address as IXLRangeAddress;

                        if (sourceCellAddress != null)
                        {
                            var mergedRange = newWorksheet.Range(sourceCellAddress);
                            mergedRange.Merge();
                        }
                    }
                }
            }

            foreach (var column in sourceWorksheet.Columns())
            {
                newWorksheet.Column(column.ColumnNumber()).Width = column.Width;
            }
        }

        public async Task<Dictionary<string, ServiceData>> ReadPullFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return null;
            }

            var serviceDataDictionary = new Dictionary<string, ServiceData>();

            using (var stream = file.OpenReadStream())
            {
                using (var workbook = new XLWorkbook(stream))
                {
                    var worksheet = workbook.Worksheet(1);

                    for (int row = 2; row <= worksheet.RowsUsed().Count(); row++)
                    {
                        // Read values from each column
                        var partnerName = worksheet.Cell(row, 1).Value.ToString();
                        var serviceShortCode = worksheet.Cell(row, 4).Value.ToString();
                        var serviceName = worksheet.Cell(row, 5).Value.ToString();
                        var totalDuration = worksheet.Cell(row, 8).GetValue<double>();
                        var totalCharge = worksheet.Cell(row, 9).GetValue<double>();
                        var totalPreeCharge = worksheet.Cell(row, 10).GetValue<double>();
                        var totalPostCharge = worksheet.Cell(row, 11).GetValue<double>();
                        var serviceRevenueShare = worksheet.Cell(row, 12).GetValue<double>();
                        var totalRevenue = worksheet.Cell(row, 16).GetValue<double>();

                        if (serviceDataDictionary.ContainsKey(serviceName))
                        {
                            var existingServiceData = serviceDataDictionary[serviceName];
                            if (existingServiceData != null)
                            {
                                existingServiceData.TotalDuration += totalDuration;
                                existingServiceData.TotalCharge += totalCharge;
                                existingServiceData.TotalPreCharge += totalPreeCharge;
                                existingServiceData.TotalPostCharge += totalPostCharge;
                                existingServiceData.TotalRevenue += totalRevenue;
                            }
                        }
                        else
                        {
                            
                            //var PNA = (double)await _excelRepository.GetPNAValueFromServiceName(serviceName);
                            var serviceData = new ServiceData
                            {
                                PartnerName = partnerName,
                                ServiceShortCode = serviceShortCode,
                                ServiceName = serviceName,
                                TotalDuration = totalDuration,
                                TotalCharge = totalCharge,
                                TotalPostCharge = totalPostCharge,
                                TotalPreCharge = totalPreeCharge,
                                TotalRevenue = totalRevenue,
                                ServiceRevenueShare = serviceRevenueShare,
                                //ServicePNA = PNA ,

                            };
                            serviceDataDictionary.Add(serviceName, serviceData);
                        }
                    }
                }
            }

            return serviceDataDictionary;
        }

        public async Task<(Dictionary<string, ServiceData>, PushFreeServices)> ReadPushFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return (null, null);

            }

            var serviceDataDictionary = new Dictionary<string, ServiceData>();
            var pushFreeServices = new PushFreeServices();


            using (var stream = file.OpenReadStream())
            {
                int startSecondTable = 0;
                using (var workbook = new XLWorkbook(stream))
                {
                    var worksheet = workbook.Worksheet(1);


                    for (int row = 2; row <= worksheet.RowsUsed().Count(); row++)
                    {
                        if (worksheet.Row(row).IsEmpty())
                        {
                            startSecondTable = row++;
                            break;
                        }
                        // Read values from each column
                        var partnerName = worksheet.Cell(row, 1).Value.ToString();
                        var serviceShortCode = worksheet.Cell(row, 2).Value.ToString();
                        var serviceName = worksheet.Cell(row, 7).Value.ToString();
                        var totalDuration = worksheet.Cell(row, 8).GetValue<double>();
                        var totalCharge = worksheet.Cell(row, 9).GetValue<double>();
                        var totalPreeCharge = worksheet.Cell(row, 11).GetValue<double>();
                        var totalPostCharge = worksheet.Cell(row, 10).GetValue<double>();
                        var serviceRevenueShare = worksheet.Cell(row, 12).GetValue<double>();
                        var totalRevenue = worksheet.Cell(row, 16).GetValue<double>();

                        if (serviceDataDictionary.ContainsKey(serviceName))
                        {
                            var existingServiceData = serviceDataDictionary[serviceName];
                            if (existingServiceData != null)
                            {
                                existingServiceData.TotalDuration += totalDuration;
                                existingServiceData.TotalCharge += totalCharge;
                                existingServiceData.TotalPreCharge += totalPreeCharge;
                                existingServiceData.TotalPostCharge += totalPostCharge;
                                existingServiceData.TotalRevenue += totalRevenue;
                            }
                        }
                        else
                        {
                            //var PNA = (double)await _excelRepository.GetPNAValueFromServiceName(serviceName);
                            var serviceData = new ServiceData
                            {
                                PartnerName = partnerName,
                                ServiceShortCode = serviceShortCode,
                                ServiceName = serviceName,
                                TotalDuration = totalDuration,
                                TotalCharge = totalCharge,
                                TotalPostCharge = totalPostCharge,
                                TotalPreCharge = totalPreeCharge,
                                TotalRevenue = totalRevenue,
                                ServiceRevenueShare = serviceRevenueShare,
                                //ServicePNA = PNA

                            };
                            serviceDataDictionary.Add(serviceName, serviceData);
                        }
                    }


                    pushFreeServices.FreeUsers = worksheet.Cell(startSecondTable + 2, 12).GetValue<double>();
                    pushFreeServices.Price = worksheet.Cell(startSecondTable + 2, 13).GetValue<double>();
                    pushFreeServices.Total = worksheet.Cell(startSecondTable + 2, 14).GetValue<double>();
                    pushFreeServices.PNA = worksheet.Cell(startSecondTable + 2, 15).GetValue<double>();
                    pushFreeServices.FinalBilledAmount = worksheet.Cell(startSecondTable + 2, 16).GetValue<double>();

                }
            }

            return (serviceDataDictionary, pushFreeServices);
        }
        public async Task<Dictionary<string, ServiceData>> ReadDCBFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return null;
            }

            var serviceDataDictionary = new Dictionary<string, ServiceData>();

            using (var stream = file.OpenReadStream())
            {
                using (var workbook = new XLWorkbook(stream))
                {
                    var worksheet = workbook.Worksheet(1);

                    for (int row = 2; row <= worksheet.RowsUsed().Count(); row++)
                    {
                        // Read values from each column
                        var partnerName = worksheet.Cell(row, 4).Value.ToString();
                        var serviceName = worksheet.Cell(row, 5).Value.ToString();
                        var totalDuration = worksheet.Cell(row, 6).GetValue<double>();
                        var totalCharge = worksheet.Cell(row, 7).GetValue<double>();
                        var serviceRevenueShare = worksheet.Cell(row, 10).GetValue<double>();
                        var totalRevenue = worksheet.Cell(row, 14).GetValue<double>();

                        if (serviceDataDictionary.ContainsKey(serviceName))
                        {
                            var existingServiceData = serviceDataDictionary[serviceName];
                            if (existingServiceData != null)
                            {
                                existingServiceData.TotalDuration += totalDuration;
                                existingServiceData.TotalCharge += totalCharge;
                                existingServiceData.TotalRevenue += totalRevenue;
                            }
                        }
                        else
                        {
                            //var PNA = (double)await _excelRepository.GetPNAValueFromServiceName(serviceName);
                            var serviceData = new ServiceData
                            {
                                PartnerName = partnerName,
                                ServiceName = serviceName,
                                TotalDuration = totalDuration,
                                TotalCharge = totalCharge,
                                TotalRevenue = totalRevenue,
                                ServiceRevenueShare = serviceRevenueShare,
                               // ServicePNA = PNA

                            };
                            serviceDataDictionary.Add(serviceName, serviceData);
                        }
                    }
                }
            }

            return serviceDataDictionary;
        }

        public IFormFile WriteDCBFile(Dictionary<string, ServiceData> dcbData)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Sheet1");


                // Write headers to the first row
                worksheet.Cell(1, 1).Value = "Service Provider Name";
                worksheet.Cell(1, 2).Value = "Short Code";
                worksheet.Cell(1, 3).Value = "Service Name";
                worksheet.Cell(1, 4).Value = "Tariff";
                worksheet.Cell(1, 5).Value = "Number Of Hits";
                worksheet.Cell(1, 6).Value = "Revenue";
                worksheet.Cell(1, 7).Value = "Revenue after PNA";
                worksheet.Cell(1, 8).Value = " MW & SP RS%";
                worksheet.Cell(1, 9).Value = "MW & SP RS ILS";
              
                SetHeaderStyle(worksheet );

                // Write data to the worksheet
                int row = 2;
                foreach (var serviceData in dcbData.Values)
                {
                   
                    worksheet.Cell(row, 1).Value = serviceData.PartnerName;
                    worksheet.Cell(row, 3).Value = serviceData.ServiceName;
                    worksheet.Cell(row, 4).Value = serviceData.TotalCharge / serviceData.TotalDuration;
                    worksheet.Cell(row, 5).Value = serviceData.TotalDuration;
                    worksheet.Cell(row, 6).Value = serviceData.TotalCharge;
                    worksheet.Cell(row, 7).Value = serviceData.TotalCharge * (1- serviceData.ServicePNA);
                    worksheet.Cell(row, 8).Value = serviceData.ServiceRevenueShare;
                    worksheet.Cell(row, 9).Value = serviceData.TotalRevenue;
                  
                    row++;
                }

                // Save the workbook to a MemoryStream
                var file = SaveWorkbook(workbook);
                return file;
            }
        }

        public IFormFile WritePushFile(Dictionary<string, ServiceData> pushData, PushFreeServices freeServicesData)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Sheet1");

                // Write headers to the first row
                worksheet.Cell(1, 1).Value = "PARTNER";
                worksheet.Cell(1, 2).Value = "SUBSCRIPTION_CODE";
                worksheet.Cell(1, 3).Value = "SERVICE_DESC";
                worksheet.Cell(1, 4).Value = "SERVICE_ID";
                worksheet.Cell(1, 5).Value = "PNA";
                worksheet.Cell(1, 6).Value = "REVENUE_SHARE";
                worksheet.Cell(1, 7).Value = "Pre Price";
                worksheet.Cell(1, 8).Value = "POST_PRICE";
                worksheet.Cell(1, 9).Value = " PRE_SUBS_COUNT";
                worksheet.Cell(1, 10).Value = " POST_SUBS_COUNT";
                worksheet.Cell(1, 11).Value = " PRE_REVENUE";
                worksheet.Cell(1, 12).Value = " POST_REVENUE";
                worksheet.Cell(1, 13).Value = "NET_REV_CNT_BASED";
                worksheet.Cell(1, 14).Value = "REV_SHARE_CNT_BASED";

                SetHeaderStyle(worksheet);

                // Write data to the worksheet
                int row = 2;
                foreach (var serviceData in pushData.Values)
                {
                    var preSmsCount = serviceData.TotalPreCharge / serviceData.TotalCharge * serviceData.TotalDuration;
                    var postSmsCount = serviceData.TotalPostCharge / serviceData.TotalCharge * serviceData.TotalDuration;

                    worksheet.Cell(row, 1).Value = serviceData.PartnerName;
                    worksheet.Cell(row, 2).Value = serviceData.ServiceShortCode;
                    worksheet.Cell(row, 3).Value = serviceData.ServiceName;
                    worksheet.Cell(row, 5).Value = serviceData.ServicePNA;
                    worksheet.Cell(row, 6).Value = serviceData.ServiceRevenueShare;
                    worksheet.Cell(row, 7).Value = serviceData.TotalPreCharge / preSmsCount;
                    worksheet.Cell(row, 8).Value = serviceData.TotalPostCharge / postSmsCount;
                    worksheet.Cell(row, 9).Value = preSmsCount;
                    worksheet.Cell(row, 10).Value = postSmsCount;
                    worksheet.Cell(row, 11).Value = serviceData.TotalPreCharge;
                    worksheet.Cell(row, 12).Value = serviceData.TotalPostCharge;
                    worksheet.Cell(row, 13).Value = serviceData.TotalCharge * (1 - serviceData.ServicePNA);
                    worksheet.Cell(row, 14).Value = serviceData.TotalRevenue;

                    row++;
                }

                int secondTableStartRow = row + 2;

                worksheet.Cell(row + 1, 1).Value = "No.Free Users";
                worksheet.Cell(row + 1, 2).Value = "Price";
                worksheet.Cell(row + 1, 3).Value = "Total";
                worksheet.Cell(row + 1, 4).Value = "PNA";
                worksheet.Cell(row + 1, 5).Value = "Final Billed amount";


                //worksheet.Cell(secondTableStartRow, 1).Value = "service Free";
                worksheet.Cell(secondTableStartRow, 1).Value = freeServicesData.FreeUsers;
                worksheet.Cell(secondTableStartRow, 2).Value = freeServicesData.Price;
                worksheet.Cell(secondTableStartRow, 3).Value = freeServicesData.Total;
                worksheet.Cell(secondTableStartRow, 4).Value = freeServicesData.PNA;
                worksheet.Cell(secondTableStartRow, 5).Value = freeServicesData.FinalBilledAmount;

                // Set background color for the entire second table
                SetSecondTableStyle(worksheet, row);

                // Save the workbook to a MemoryStream
                var file = SaveWorkbook(workbook);
                return file;
            }
        }


        public IFormFile WritePullFile(Dictionary<string, ServiceData> pullData)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Sheet1");


                // Write headers to the first row
                worksheet.Cell(1, 1).Value = "PARTNER";
                worksheet.Cell(1, 2).Value = "SERVICE";
                worksheet.Cell(1, 3).Value = "SERVICE_DESC";
                worksheet.Cell(1, 4).Value = "REVENUE_SHARE";
                worksheet.Cell(1, 5).Value = "PNA";
                worksheet.Cell(1, 6).Value = "PRE_PRICE_VAT_EX";
                worksheet.Cell(1, 7).Value = "POST_PRICE_VAT_EX";
                worksheet.Cell(1, 8).Value = " PRE_CDRS_COUNT";
                worksheet.Cell(1, 9).Value = "POST_CDRS_COUNT";
                worksheet.Cell(1, 10).Value = " CDRS_COUNT";
                worksheet.Cell(1, 11).Value = "PRE_REVENUE";
                worksheet.Cell(1, 12).Value = "POST_REVENUE";
                worksheet.Cell(1, 13).Value = "TOTAL_REVENUE";
                worksheet.Cell(1, 14).Value = "TOTAL_SHARE";

                SetHeaderStyle(worksheet);

                // Write data to the worksheet
                int row = 2;
                foreach (var serviceData in pullData.Values)
                {
                    var preSmsCount = serviceData.TotalPreCharge / serviceData.TotalCharge * serviceData.TotalDuration;
                    var postSmsCount = serviceData.TotalPostCharge / serviceData.TotalCharge * serviceData.TotalDuration;

                    worksheet.Cell(row, 1).Value = serviceData.PartnerName;
                    worksheet.Cell(row, 2).Value = serviceData.ServiceShortCode;
                    worksheet.Cell(row, 3).Value = serviceData.ServiceName;
                    worksheet.Cell(row, 4).Value = serviceData.ServiceRevenueShare;
                    worksheet.Cell(row, 5).Value = serviceData.ServicePNA;
                    worksheet.Cell(row, 6).Value = serviceData.TotalPreCharge / preSmsCount;
                    worksheet.Cell(row, 7).Value = serviceData.TotalPostCharge / postSmsCount;
                    worksheet.Cell(row, 8).Value = preSmsCount;
                    worksheet.Cell(row, 9).Value = postSmsCount;
                    worksheet.Cell(row, 10).Value = serviceData.TotalDuration;
                    worksheet.Cell(row, 11).Value = serviceData.TotalPreCharge;
                    worksheet.Cell(row, 12).Value = serviceData.TotalPostCharge;
                    worksheet.Cell(row, 13).Value = serviceData.TotalCharge * (1 - serviceData.ServicePNA);
                    worksheet.Cell(row, 14).Value = serviceData.TotalRevenue;

                    row++;
                }

                // Save the workbook to a MemoryStream
                var file = SaveWorkbook(workbook);
                return file;
            }
        }

        public IFormFile SaveWorkbook(XLWorkbook workbook)
        {
            using (var stream = new MemoryStream())
            {
                workbook.SaveAs(stream);
                stream.Position = 0; // Reset position

                // Create a new MemoryStream and copy the content
                var copyStream = new MemoryStream();
                stream.CopyTo(copyStream);

                // Reset the position of the original stream
                stream.Position = 0;

                // Create an IFormFile from the copied MemoryStream
                var formFile = new FormFile(copyStream, 0, copyStream.Length, "Sheet1", "Pull.xlsx");
                return formFile;
            }
        }

        public void SetHeaderStyle(IXLWorksheet worksheet)
        {
            for (int column = 1; column <= 14; column++)
            {
                worksheet.Cell(1, column).Style.Fill.BackgroundColor = XLColor.FromHtml("#C4D79B");
                worksheet.Cell(1, column).Style.Border
                    .SetOutsideBorder(XLBorderStyleValues.Thin).Border
                    .SetOutsideBorderColor(XLColor.Black); ;

                worksheet.Column(column).Width = 20;
                worksheet.Column(column).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left; // Justify the text

            }
        }

        public void SetSecondTableStyle(IXLWorksheet worksheet, int row)
        {
            for (int i = 1; i <= 5; i++)
            {
                worksheet.Cell(row + 1, i).Style.Fill.BackgroundColor = XLColor.FromHtml("#9E7800");
                worksheet.Cell(row + 1, i).Style.Border
                         .SetOutsideBorder(XLBorderStyleValues.Thin).Border
                         .SetOutsideBorderColor(XLColor.Black);

                worksheet.Cell(row + 2, i).Style.Fill.BackgroundColor = XLColor.FromHtml("#9E7800");
                worksheet.Cell(row + 2, i).Style.Border
                                          .SetOutsideBorder(XLBorderStyleValues.Thin).Border
                                          .SetOutsideBorderColor(XLColor.Black);

            }
        }

    }
}
