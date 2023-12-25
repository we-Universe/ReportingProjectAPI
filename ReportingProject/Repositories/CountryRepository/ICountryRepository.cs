using Microsoft.AspNetCore.Identity;
using ReportingProject.Data.Entities;

namespace ReportingProject.Repositories.CountryRepository
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country>> GetAllCountriesAsync();
    }
}
