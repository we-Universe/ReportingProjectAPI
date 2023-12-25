using AutoMapper;
using DocumentFormat.OpenXml.Bibliography;
using ReportingProject.Data.Entities;
using ReportingProject.Data.Models;
using ReportingProject.Data.Resources;
using ReportingProject.Repositories.OperatorReportRepository;
using ReportingProject.Repositories.ReportRepository;

namespace ReportingProject.Services.ReportService
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;
        private readonly IOperatorReportRepository _reportOperatorRepository;
        private readonly IMapper _mapper;

        public ReportService(IReportRepository reportRepository, IMapper mapper, IOperatorReportRepository reportOperatorRepository)
        {
            _reportRepository = reportRepository;
            _mapper = mapper;
            _reportOperatorRepository = reportOperatorRepository;
        }

        public async Task UploadReportAsync(ReportModel model)
        {
            try
            {
                var reportEntity = _mapper.Map<Report>(model);
                await _reportRepository.UploadReportAsync(reportEntity);

                var operatorReport = new OperatorReportsModel
                {
                    ReportId = reportEntity.Id,
                    OperatorId = model.OperatorId,
                    IMIFile = model.IMIFile,
                    DifferencesFile = model.DifferencesFile,
                    MWFile = model.MWFile,
                    RefundFile = model.RefundFile
                };

                var operatorReportEntity = _mapper.Map<OperatorReport>(operatorReport);
                await _reportOperatorRepository.UploadReportAsync(operatorReportEntity);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(operatorReport);
                throw; 
            }
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