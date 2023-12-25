using AutoMapper;
using ReportingProject.Data.Entities;
using ReportingProject.Data.Resources;
using ReportingProject.Repositories.OperatorReportRepository;

namespace ReportingProject.Services.OperatorReportService
{
	public class OperatorReportService : IOperatorReportService
    {
        private readonly IOperatorReportRepository _reportRepository;
        private readonly IMapper _mapper;

        public OperatorReportService(IOperatorReportRepository reportRepository, IMapper mapper)
        {
            _reportRepository = reportRepository;
            _mapper = mapper;
        }

        public Task UploadReportAsync(OperatorReport entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteReportAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<OperatorReportsResource>> GetAllReportsAsync()
        {
            var reportsEntities = await _reportRepository.GetAllReportsAsync();
            return _mapper.Map<IEnumerable<OperatorReportsResource>>(reportsEntities);
        }

        public Task<OperatorReport> GetReportByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateReportAsync(OperatorReport entity)
        {
            throw new NotImplementedException();
        }
    }
}