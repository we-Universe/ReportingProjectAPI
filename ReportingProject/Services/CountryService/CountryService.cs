using AutoMapper;
using ReportingProject.Data.Resources;
using ReportingProject.Repositories.CountryRepository;

namespace ReportingProject.Services.CountryService
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public CountryService(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CountryResource>> GetAllCountriesAsync()
        {
            var countries = await _countryRepository.GetAllCountriesAsync();
            return _mapper.Map<IEnumerable<CountryResource>>(countries);
        }
    }
}
