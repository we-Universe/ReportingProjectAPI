namespace ReportingProject.Services.OperatorService
{
	public interface IOperatorService
	{
        Task<int> GetOperatorIdByCompanyNameAsync(string name);

    }
}

