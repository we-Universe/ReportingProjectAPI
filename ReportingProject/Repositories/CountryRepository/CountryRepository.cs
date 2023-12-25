using Microsoft.EntityFrameworkCore;
using ReportingProject.Data.Contextes;
using ReportingProject.Data.Entities;

namespace ReportingProject.Repositories.CountryRepository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly ReportingDBContext _reportingDBContext;
        private readonly DbSet<Country> _dbSet;
        public CountryRepository(ReportingDBContext reportingDBContex)
        {
            _reportingDBContext = reportingDBContex;
            _dbSet = _reportingDBContext.Set<Country>();
        }
        public async Task<IEnumerable<Country>> GetAllCountriesAsync()
        {
            return await _dbSet.ToListAsync();
        }
    }
}
