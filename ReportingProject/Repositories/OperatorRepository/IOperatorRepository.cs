namespace ReportingProject.Repositories.OperatorRepository
{
	public interface IOperatorRepository
	{
        Task<int> GetOperatorIdByCompanyNameAsync(string companyName);
    }
}

