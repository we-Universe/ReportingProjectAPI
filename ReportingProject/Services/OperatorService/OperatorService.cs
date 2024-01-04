using AutoMapper;
using ReportingProject.Repositories.OperatorRepository;

namespace ReportingProject.Services.OperatorService
{
	public class OperatorService : IOperatorService
    {
        private readonly IOperatorRepository _operatorRepository;
        private readonly IMapper _mapper;

        public OperatorService(IOperatorRepository operatorRepository, IMapper mapper)
        {
            _operatorRepository = operatorRepository;
            _mapper = mapper;
        }

        public async Task<int> GetOperatorIdByCompanyNameAsync(string name)
        {
            int operatorId = await _operatorRepository.GetOperatorIdByCompanyNameAsync(name);
            return operatorId;
        }
    }
}