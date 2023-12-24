using ReportingProject.Data.Entities;
using ReportingProject.Repositories.ReportTypeRepository;

namespace ReportingProject.Services.ReportTypeService
{
    public class ReportTypeService : IReportTypeService
    {
        private readonly IReportTypeRepository _reportTypeRepository;

        public ReportTypeService(IReportTypeRepository reportTypeRepository)
        {
            _reportTypeRepository = reportTypeRepository;
        }
        public Task AddReportTypeAsync(ReportType entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteReportTypeAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ReportType>> GetAllReportsTypesAsync()
        {
              return await _reportTypeRepository.GetAllReportsTypesAsync();
        }

        public Task<ReportType> GetReportTypeByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateReportTypeAsync(ReportType entity)
        {
            throw new NotImplementedException();
        }
    }
}
