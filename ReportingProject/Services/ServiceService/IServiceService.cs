namespace ReportingProject.Services.ServiceService
{
	public interface IServiceService
	{
        Task<int> GetServiceIdFromServiceNameAsync(string name);
    }
}