using System.Runtime.InteropServices;
using AutoMapper;
using ReportingProject.Data.Entities;
using ReportingProject.Data.Models;
using ReportingProject.Repositories.RevenueRepository;
using Microsoft.Office.Interop.Excel;
using ClosedXML.Excel;

namespace ReportingProject.Services.RevenueService
{
    public class RevenueService : IRevenueService
    {
        private readonly IRevenueRepository _revenueRepository;
        private readonly IMapper _mapper;

        public RevenueService(IRevenueRepository revenueRepository, IMapper mapper)
        {
            _revenueRepository = revenueRepository;
            _mapper = mapper;
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

        public void ProcessExcelFile(IFormFile file)
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
                        var TotalSubscriptions = (double)worksheet.Cell(row, 9).Value + (double)worksheet.Cell(row, 10).Value;
                        var PostSubscriptions = (double)worksheet.Cell(row, 10).Value;
                    }

                    var worksheet_2 = workbook.Worksheet(2);

                    for (int row = 2; row <= worksheet_2.RowsUsed().Count(); row++)
                    {
                        var serviceName = worksheet_2.Cell(row, 3).Value.ToString();
                        var TotalSubscriptions = (double)worksheet_2.Cell(row, 10).Value;
                        var PostSubscriptions = (double)worksheet_2.Cell(row, 9).Value;
                    }

                    var worksheet_3 = workbook.Worksheet(3);

                    for (int row = 2; row <= worksheet_3.RowsUsed().Count(); row++)
                    {
                        var serviceName = worksheet_3.Cell(row, 3).Value.ToString();
                        var TotalSubscriptions = (double)worksheet_3.Cell(row,5).Value;
                    }
                }
            }
        }

        public IFormFile ConvertToIFormFile(string filePath)
        {
            byte[] fileBytes = File.ReadAllBytes(filePath);
            MemoryStream memoryStream = new MemoryStream(fileBytes);
            IFormFile formFile = new FormFile(memoryStream, 0, memoryStream.Length, "excelFile", Path.GetFileName(filePath));
            return formFile;
        }
    }
}