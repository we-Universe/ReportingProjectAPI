using ClosedXML.Excel;
using ReportingProject.Data.DTO;
using ReportingProject.Repositories.ServiceRepository;

namespace ReportingProject.Helpers.MergeExcelHelper
{
    public class MergeExcelHelper : IMergeExcelHelper
    {
        public readonly IServiceRepository _serviceRepository;
        public MergeExcelHelper(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
         
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
                                //ServicePNA = (double)await _serviceRepository.GetPNAValueFromServiceNameAsync(serviceName) ,

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
                                //ServicePNA = (double)await _serviceRepository.GetPNAValueFromServiceNameAsync(serviceName),

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
                         
                            var serviceData = new ServiceData
                            {
                                PartnerName = partnerName,
                                ServiceName = serviceName,
                                TotalDuration = totalDuration,
                                TotalCharge = totalCharge,
                                TotalRevenue = totalRevenue,
                                ServiceRevenueShare = serviceRevenueShare,
                                //ServicePNA = (double)await _serviceRepository.GetPNAValueFromServiceNameAsync(serviceName),

                            };
                            serviceDataDictionary.Add(serviceName, serviceData);
                        }
                    }
                }
            }

            return serviceDataDictionary;
        }

        public void WriteDCBFile(Dictionary<string, ServiceData> dcbData, XLWorkbook workbook)
        {
            var worksheet = workbook.Worksheet("DCB");

            // Write data to the worksheet starting from row 2
            int row = 2;
            foreach (var serviceData in dcbData.Values)
            {

                worksheet.Cell(row, 1).Value = serviceData.PartnerName;
                worksheet.Cell(row, 3).Value = serviceData.ServiceName;
                worksheet.Cell(row, 4).Value = serviceData.TotalCharge / serviceData.TotalDuration;
                worksheet.Cell(row, 5).Value = serviceData.TotalDuration;
                worksheet.Cell(row, 6).Value = serviceData.TotalCharge;
                worksheet.Cell(row, 7).Value = serviceData.TotalCharge * (1 - serviceData.ServicePNA);
                worksheet.Cell(row, 8).Value = serviceData.ServiceRevenueShare;
                worksheet.Cell(row, 9).Value = serviceData.TotalRevenue;

                row++;
            }

      
        }

        public void  WritePushFile(Dictionary<string, ServiceData> pushData, PushFreeServices freeServicesData, XLWorkbook workbook)
        {
            var worksheet = workbook.Worksheet("Push");

            // Write data to the worksheet starting from row 2
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

            worksheet.Cell(secondTableStartRow, 1).Value = freeServicesData.FreeUsers;
            worksheet.Cell(secondTableStartRow, 2).Value = freeServicesData.Price;
            worksheet.Cell(secondTableStartRow, 3).Value = freeServicesData.Total;
            worksheet.Cell(secondTableStartRow, 4).Value = freeServicesData.PNA;
            worksheet.Cell(secondTableStartRow, 5).Value = freeServicesData.FinalBilledAmount;

        }

        public void WritePullFile(Dictionary<string, ServiceData> pullData, XLWorkbook workbook)
        {
            var worksheet = workbook.Worksheet("Pull");

            //Write data to the worksheet starting from row 2
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

        }

        
    }
}
