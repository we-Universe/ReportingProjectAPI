namespace ReportingProject.Services.MerchantService
{
	public interface IMerchantService
	{
        Task<int?> GetMerchantIdByEmployeeNameAsync(string employeeName);
    }
}