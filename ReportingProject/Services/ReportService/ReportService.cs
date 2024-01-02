using AutoMapper;
using DocumentFormat.OpenXml.Bibliography;
using ReportingProject.Data.Entities;
using ReportingProject.Data.Models;
using ReportingProject.Data.Resources;
using ReportingProject.Repositories.MerchantReportRepository;
using ReportingProject.Repositories.OperatorReportRepository;
using ReportingProject.Repositories.ReportRepository;

namespace ReportingProject.Services.ReportService
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;
        private readonly IOperatorReportRepository _reportOperatorRepository;
        private readonly IMapper _mapper;

        public ReportService(IReportRepository reportRepository, IMapper mapper, IOperatorReportRepository reportOperatorRepository, IMerchantReportRepository reportMerchantRepository)
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
                Console.Error.WriteLine(ex.Message);
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

        public async Task<IEnumerable<ReportResource>> GetReportByReportIdAsync(int reportId)
        {
            var reportsEntities = await _reportRepository.GetReportByReportIdAsync(reportId);
            return _mapper.Map<IEnumerable<ReportResource>>(reportsEntities);
        }

        public async Task<IEnumerable<ReportAndOperatorResource>> GetReportByOperatorReportIdAsync()
        {
            var reportsEntities = await _reportRepository.GetReportsByOperatorIdAsync();
            return _mapper.Map<IEnumerable<ReportAndOperatorResource>>(reportsEntities);
        }

        public async Task<IEnumerable<ReportAndOperatorAnotherFormatResource>> GetReportsByOperatorReportAsync()
        {
            var reportsEntities = await _reportRepository.GetReportsByOperatorReportAsync();
            return _mapper.Map<IEnumerable<ReportAndOperatorAnotherFormatResource>>(reportsEntities);
        }

        public async Task<IEnumerable<ReportAndMerchantResource>> GetReportsByMerchantReportAsync()
        {
            var reportsEntities = await _reportRepository.GetReportsByMerchantReportAsync();
            return _mapper.Map<IEnumerable<ReportAndMerchantResource>>(reportsEntities);
        }

        public async Task UpdateReportAsync(ReportModel model)
        {
            try
            {
                var reportEntity = await _reportRepository.GetReportByIdAsync(model.Id);
                reportEntity = _mapper.Map(model, reportEntity);
                await _reportRepository.UpdateReportAsync(reportEntity);
                int id = await _reportOperatorRepository.GetOperatorIdFromReportIdAsync(model.Id);

                var operatorReportModel = new OperatorReportsModel
                {
                    Id = id,
                    ReportId = model.Id,
                    OperatorId =model.OperatorId,
                    IMIFile = model.IMIFile,
                    DifferencesFile = model.DifferencesFile,
                    MWFile = model.MWFile,
                    RefundFile = model.RefundFile
                };

                var operatorReportEntity = _mapper.Map<OperatorReport>(operatorReportModel);
                await _reportOperatorRepository.UpdateReportAsync(operatorReportEntity);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                throw;
            }
        }
    }
}