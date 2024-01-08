using AutoMapper;
using ReportingProject.Data.Entities;
using ReportingProject.Data.Models;
using ReportingProject.Repositories.RevenueRepository;
using ClosedXML.Excel;
using ReportingProject.Repositories.ServiceRepository;
using DocumentFormat.OpenXml.Drawing;

namespace ReportingProject.Services.RevenueService
{
    public class RevenueService : IRevenueService
    {
        private readonly IRevenueRepository _revenueRepository;
        private readonly IServiceRepository _serviceRepository;
        private readonly IMapper _mapper;

        public RevenueService(IRevenueRepository revenueRepository, IMapper mapper, IServiceRepository serviceRepository)
        {
            _revenueRepository = revenueRepository;
            _mapper = mapper;
            _serviceRepository = serviceRepository;
        }

        public async Task UploadRevenueAsync(RevenueModel model)
        {
            try
            {
                var operatorRevenueEntity = _mapper.Map<Revenue>(model);
                await _revenueRepository.UploadRevenueAsync(operatorRevenueEntity);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task ProcessExcelFile(IFormFile file, int month, int year)
        {
            if (file == null || file.Length == 0)
            {
                return;
            }

            using (var stream = file.OpenReadStream())
            {
                using (var workbook = new XLWorkbook(stream))
                {
                    var worksheet = workbook.Worksheet(1);

                    for (int row = 2; row <= worksheet.RowsUsed().Count(); row++)
                    {
                        var serviceName = worksheet.Cell(row, 3).Value.ToString();
                        if (serviceName == "")
                            break;
                        decimal clientShare = await _serviceRepository.GetClientShareFromServiceNameAsync(serviceName);
                        string operatorCountry = await _serviceRepository.GetOperatorCountryFromServiceNameAsync(serviceName);
                        string merchantCountry = await _serviceRepository.GetMerchantNameFromServiceNameAsync(serviceName);
                        decimal nonResidentialValue = await _serviceRepository.GetNonResidentialValueFromServiceName(serviceName);
                        int serviceId = await _serviceRepository.GetServiceIdFromServiceNameAsync(serviceName.ToString());
                        int TotalSubscriptions = (int)worksheet.Cell(row, 9).Value + (int)worksheet.Cell(row, 10).Value;
                        int PostSubscriptions = (int)worksheet.Cell(row, 10).Value;
                        var revenue = decimal.TryParse(worksheet.Cell(row, 13).Value.ToString(), out var result) ? result : 0;
                        decimal merchantRevenue = revenue * clientShare * ((operatorCountry != merchantCountry) ? nonResidentialValue : 1.0m);
                        decimal consultantShare = await _serviceRepository.GetConsultantShareFromServiceNameAsync(serviceName);
                        decimal universeRevenue = revenue * (1-clientShare) * consultantShare;

                        var revenueModel = new RevenueModel
                        {
                            ServiceId = serviceId,
                            TotalSubscriptions = TotalSubscriptions,
                            PostSubscriptions = PostSubscriptions,
                            Month = month,
                            Year = year,
                            MerchantRevenue = merchantRevenue,
                            UniverseRevenue = universeRevenue
                        };

                        await UploadRevenueAsync(revenueModel);
                    }

                    var worksheet_2 = workbook.Worksheet(2);

                    for (int row = 2; row <= worksheet_2.RowsUsed().Count(); row++)
                    {
                        var serviceName = worksheet_2.Cell(row, 3).Value.ToString();
                        if (serviceName == "")
                            break;
                        decimal clientShare = await _serviceRepository.GetClientShareFromServiceNameAsync(serviceName);
                        int serviceId = await _serviceRepository.GetServiceIdFromServiceNameAsync(serviceName);
                        var TotalSubscriptions = (int)worksheet_2.Cell(row, 10).Value;
                        var PostSubscriptions = (int)worksheet_2.Cell(row, 9).Value;
                        var revenue = decimal.TryParse(worksheet.Cell(row, 13).Value.ToString(), out var result) ? result : 0;
                        string operatorCountry = await _serviceRepository.GetOperatorCountryFromServiceNameAsync(serviceName);
                        string merchantCountry = await _serviceRepository.GetMerchantNameFromServiceNameAsync(serviceName);
                        decimal nonResidentialValue = await _serviceRepository.GetNonResidentialValueFromServiceName(serviceName);
                        decimal merchantRevenue = revenue * clientShare * ((operatorCountry != merchantCountry) ? nonResidentialValue : 1.0m);
                        decimal consultantShare = await _serviceRepository.GetConsultantShareFromServiceNameAsync(serviceName);
                        decimal universeRevenue = revenue * (1 - clientShare) * consultantShare;

                        var revenueModel = new RevenueModel
                        {
                            ServiceId = serviceId,
                            TotalSubscriptions = TotalSubscriptions,
                            PostSubscriptions = PostSubscriptions,
                            Month = month,
                            Year = year,
                            MerchantRevenue = merchantRevenue,
                            UniverseRevenue = universeRevenue
                        };

                        await UploadRevenueAsync(revenueModel);
                    }

                    var worksheet_4 = workbook.Worksheet(4);

                    Dictionary<string, decimal> serviceRefundDictionary = new Dictionary<string, decimal>();
                    for (int row = 2; row <= worksheet_4.RowsUsed().Count(); row++)
                    {
                        var serviceName = worksheet_4.Cell(row, 2).Value.ToString();
                        if (serviceName == "")
                            break;

                        if (decimal.TryParse(worksheet_4.Cell(row, 5).Value.ToString(), out decimal refund))
                        {
                            if (serviceRefundDictionary.ContainsKey(serviceName))
                            {
                                serviceRefundDictionary[serviceName] += refund;
                            }
                            else
                            {
                                serviceRefundDictionary[serviceName] = refund;
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Error parsing refund for service '{serviceName}' at row {row}");
                        }
                    }

                    var worksheet_3 = workbook.Worksheet(3);

                    for (int row = 2; row <= worksheet_3.RowsUsed().Count(); row++)
                    {
                        var serviceName = worksheet_3.Cell(row, 3).Value.ToString();
                        if (serviceName == "")
                            break;

                        decimal clientShare = await _serviceRepository.GetClientShareFromServiceNameAsync(serviceName);
                        if (serviceRefundDictionary.TryGetValue(serviceName, out decimal tempRefundValue))
                        {
                            var refundValue = tempRefundValue;
                            var TotalSubscriptions = (int)worksheet_3.Cell(row, 5).Value;
                            int serviceId = await _serviceRepository.GetServiceIdFromServiceNameAsync(serviceName.ToString());
                            var revenue = decimal.TryParse(worksheet.Cell(row, 9).Value.ToString(), out var result) ? result : 0;
                            string operatorCountry = await _serviceRepository.GetOperatorCountryFromServiceNameAsync(serviceName);
                            string merchantCountry = await _serviceRepository.GetMerchantNameFromServiceNameAsync(serviceName);
                            decimal nonResidentialValue = await _serviceRepository.GetNonResidentialValueFromServiceName(serviceName);
                            decimal merchantRevenue = (revenue - refundValue) * clientShare * ((operatorCountry!=merchantCountry) ? nonResidentialValue : 1.0m);
                            decimal consultantShare = await _serviceRepository.GetConsultantShareFromServiceNameAsync(serviceName);
                            decimal universeRevenue = (revenue - refundValue) * (1 - clientShare) * consultantShare;

                            var revenueModel = new RevenueModel
                            {
                                ServiceId = serviceId,
                                TotalSubscriptions = TotalSubscriptions,
                                Refund= refundValue,
                                Month = month,
                                Year = year,
                                MerchantRevenue = merchantRevenue,
                                UniverseRevenue = universeRevenue
                            };

                            await UploadRevenueAsync(revenueModel);
                        }
                        else
                        {
                            Console.WriteLine($"Service name '{serviceName}' not found in the refund dictionary.");
                        }
                    }
                }
            }
        }
    }
}