using ReportingProject.Data.Entities;

namespace ReportingProject.Repositories.RevenueRepository
{
	public interface IRevenueRepository
	{
        Task UploadRevenueAsync(Revenue entity);
    }
}