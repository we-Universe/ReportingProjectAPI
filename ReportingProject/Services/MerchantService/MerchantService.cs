using AutoMapper;
using ReportingProject.Repositories.MerchantRepository;

namespace ReportingProject.Services.MerchantService
{
	public class MerchantService : IMerchantService
    {
        private readonly IMerchantRepository _merchantreportRepository;
        private readonly IMapper _mapper;

        public MerchantService(IMerchantRepository merchantreportRepository, IMapper mapper)
        {
            _merchantreportRepository = merchantreportRepository;
            _mapper = mapper;
        }

        public async Task<int?> GetMerchantIdByEmployeeNameAsync(string employeeName)
        {
            return await _merchantreportRepository.GetMerchantIdByEmployeeNameAsync(employeeName);
        }
    }
}