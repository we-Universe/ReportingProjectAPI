namespace ReportingProject.Repositories.ServiceRepository
{
	public interface IServiceRepository
	{
        Task<int> GetServiceIdFromServiceNameAsync(string name);
    }
}