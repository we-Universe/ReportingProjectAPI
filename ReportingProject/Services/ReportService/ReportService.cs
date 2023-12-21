using AutoMapper;
using ReportingProject.Data.Entities;
using ReportingProject.Data.Resources;
using ReportingProject.Repositories.ReportRepository;

namespace ReportingProject.Services.ReportService
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;
        private readonly IMapper _mapper;

        public ReportService(IReportRepository reportRepository, IMapper mapper)
        {
            _reportRepository = reportRepository;
            _mapper = mapper;
        }
        public Task UploadReportAsync(Report entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteReportAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ReportResource>> GetAllReportsAsync()
        {
            var reportsEntities = await _reportRepository.GetAllReportsAsync();
            return _mapper.Map<IEnumerable<ReportResource>>(reportsEntities);
        }

        public Task<Report> GetReportByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateReportAsync(Report entity)
        {
            throw new NotImplementedException();
        }
    }
}
