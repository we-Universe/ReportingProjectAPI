namespace ReportingProject.Repositories.MerchantRepository
{
	public interface IMerchantRepository
	{
        Task<int?> GetMerchantIdByEmployeeNameAsync(string employeeName);
    }
}