using AutoMapper;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Office2010.Excel;
using ReportingProject.Data.Entities;
using ReportingProject.Data.Models;
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

        public async Task<IEnumerable<OperatorReportsResource>> GetAllReportsAsync()
        {
            var reportsEntities = await _reportRepository.GetAllReportsAsync();
            return _mapper.Map<IEnumerable<OperatorReportsResource>>(reportsEntities);
        }

        public async Task<OperatorReport> GetReportByIdAsync(int id)
        {
            return await _reportRepository.GetReportByIdAsync(id);
        }

        public async Task UploadOperatorReportAsync(OperatorReportsModel model)
        {
            var operatorReportEntity = _mapper.Map<OperatorReport>(model);
            await _reportRepository.UploadReportAsync(operatorReportEntity);
        }

        public async Task UpdateReportAsync(OperatorReport entity)
        {
            await _reportRepository.UpdateReportAsync(entity);
        }

        public async Task DeleteReportAsync(int id)
        {
            await _reportRepository.DeleteReportAsync(id);
        }

        public async Task<int> GetOperatorIFromReportIdAsync(int reportId)
        {
            int operatorId = await _reportRepository.GetOperatorIdFromReportIdAsync(reportId);
            return operatorId;
        }
    }
}