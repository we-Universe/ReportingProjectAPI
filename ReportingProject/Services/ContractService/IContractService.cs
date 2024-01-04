using ReportingProject.Data.Models;

namespace ReportingProject.Services.ContractService
{
	public interface IContractService
	{
        Task UploadContractAsync(ContractModel model);

    }
}

