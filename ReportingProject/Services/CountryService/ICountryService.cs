using ReportingProject.Data.Resources;

namespace ReportingProject.Services.CountryService
{
    public interface ICountryService
    {
       Task<IEnumerable<CountryResource>> GetAllCountriesAsync();

    }
}
