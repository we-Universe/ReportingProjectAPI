namespace ReportingProject.Repositories.ServiceRepository
{
	public interface IServiceRepository
	{
        Task<int> GetServiceIdFromServiceNameAsync(string name);
        Task<decimal> GetClientShareFromServiceNameAsync(string name);
        Task<bool> IsOutsidePalestineAsync(string name);
        Task<decimal> GetPNAValueFromServiceNameAsync(string name);
    }
}