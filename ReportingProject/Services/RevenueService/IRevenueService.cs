using ReportingProject.Data.Models;

namespace ReportingProject.Services.RevenueService
{
	public interface IRevenueService
	{
        Task UploadRevenueAsync(RevenueModel model);
        void ProcessExcelFile(IFormFile file);
        IFormFile ConvertToIFormFile(string filePath);
    }
}