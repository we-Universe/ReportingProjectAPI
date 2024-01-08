using ReportingProject.Data.Models;

namespace ReportingProject.Services.RevenueService
{
	public interface IRevenueService
	{
        Task UploadRevenueAsync(RevenueModel model);
        Task ProcessExcelFile(IFormFile file, int month, int year);
    }
}