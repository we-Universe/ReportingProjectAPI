
using ReportingProject.Data.Entities;

namespace ReportingProject.Repositories.ContractRepository
{
	public interface IContractRepository
	{
        Task UploadContractAsync(Contract entity);

    }
}