using AutoMapper;
using ReportingProject.Data.Entities;
using ReportingProject.Data.Models;
using ReportingProject.Repositories.ContractRepository;

namespace ReportingProject.Services.ContractService
{
	public class ContractService : IContractService
    {
        private readonly IContractRepository _contractRepository;
        private readonly IMapper _mapper;

        public ContractService(IContractRepository contractRepository, IMapper mapper)
        {
            _contractRepository = contractRepository;
            _mapper = mapper;
        }

        public async Task UploadContractAsync(ContractModel model)
        {
            try
            {
                var contractEntity = _mapper.Map<Contract>(model);
                await _contractRepository.UploadContractAsync(contractEntity);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                throw;
            }
        }
    }
}