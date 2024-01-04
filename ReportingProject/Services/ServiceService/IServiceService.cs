namespace ReportingProject.Services.ServiceService
{
	public interface IServiceService
	{
        Task<int> GetServiceIdFromServiceNameAsync(string name);
        Task<decimal> GetClientShareFromServiceNameAsync(string name);
    }
}