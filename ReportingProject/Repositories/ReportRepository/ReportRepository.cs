using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.InkML;
using Microsoft.EntityFrameworkCore;
using ReportingProject.Data.Contextes;
using ReportingProject.Data.Entities;
using ReportingProject.Data.Resources;
using ReportingProject.Repositories.MerchantReportRepository;
using ReportingProject.Repositories.OperatorReportRepository;

namespace ReportingProject.Repositories.ReportRepository
{
    public class ReportRepository : IReportRepository
    {
        private readonly ReportingDBContext _reportingDBContext;
        private readonly DbSet<Report> _dbSet;
        private readonly  IOperatorReportRepository _reportOperatorRepository;
        private readonly IMerchantReportRepository _reportMerchantRepository;

        public ReportRepository(ReportingDBContext reportingDBContex, IOperatorReportRepository reportOperatorRepository, IMerchantReportRepository reportMerchantRepository) {
            _reportingDBContext = reportingDBContex;
            _dbSet = _reportingDBContext.Set<Report>();
            _reportOperatorRepository = reportOperatorRepository;
            _reportMerchantRepository = reportMerchantRepository;
        }

        public async Task UploadReportAsync(Report entity)
        {
            try
            {
                _reportingDBContext.Reports.Add(entity);
                await _reportingDBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error saving changes to the database.", ex);
            }
        }

        public Task DeleteReportAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Report>> GetAllReportsAsync()
        {
            return await _dbSet.Include(report=>report.ReportNotes).ToListAsync();
        }

        public async Task<Report> GetReportByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id) ?? throw new Exception("Report not found");
        }

        public async Task UpdateReportAsync(Report entity)
        {
            try
            {
                _dbSet.Update(entity);
                await _reportingDBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error saving changes to the database.", ex);
            }
        }

        public async Task<IEnumerable<Report>> GetReportByReportIdAsync(int reportId)
        {
            try
            {
                var reports = await _dbSet
                    .Where(report => report.Id == reportId)
                    .ToListAsync();

                if (reports == null || !reports.Any())
                {
                    throw new Exception($"No reports found for ReportId: {reportId}");
                }

                return reports;
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching reports from the database.", ex);
            }
        }

        public async Task<IEnumerable<ReportAndOperatorResource>> GetReportsByOperatorIdAsync()
        {
            try
            {
                var operatorReports = await _reportOperatorRepository.GetAllReportsAsync();

                var distinctReportIds = operatorReports
                    .Select(operatorReport => operatorReport.ReportId)
                    .Distinct()
                    .ToList();

                var reports = await _dbSet
                    .Where(report => distinctReportIds.Contains(report.Id))
                    .Include(report => report.ReportType)
                    .Include(report => report.ApprovalStatus)
                    .Include(report => report.OperatorReport)
                        .ThenInclude(operatorReport => operatorReport.Operator)
                            .ThenInclude(operatorEntity => operatorEntity.Company)
                    .Include(report => report.ReportNotes)  
                    .ToListAsync();

                var result = reports.Select(report => new ReportAndOperatorResource
                {
                    Id = report.Id,
                    Type = report.ReportType?.Name ?? string.Empty,
                    File = report.ReportFile,
                    Notes = report.ReportNotes?.Select(note => new ReportNote { ReportId = note.ReportId, Content = note.Content }).ToList() ?? new List<ReportNote>(),
                    Approved = (report.ApprovalStatus?.Id >= 5) ? 1 : 0,
                    Month = report.Month,
                    Year = report.Year,
                    TelecomName = report.OperatorReport?.Operator?.Company?.Name ?? string.Empty,
                    Status = report.ApprovalStatus?.Name ?? string.Empty
                });

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching reports from the database.", ex);
            }
        }

        public async Task<IEnumerable<ReportAndMerchantResource>> GetReportsByMerchantReportAsync()
        {
            try
            {
                var merchantReports = await _reportMerchantRepository.GetAllMerchantsReports();

                var distinctReportIds = merchantReports
                    .Select(merchantReport => merchantReport.ReportId)
                    .Distinct()
                    .ToList();

                var reports = await _dbSet
                    .Where(report => distinctReportIds.Contains(report.Id))
                    .Include(report => report.ReportType)
                    .Include(report => report.ApprovalStatus)
                    .Include(report => report.OperatorReport)
                        .ThenInclude(operatorReport => operatorReport.Operator)
                            .ThenInclude(operatorEntity => operatorEntity.Company)
                    .Include(report => report.ReportNotes)
                    .ToListAsync();

                var result = reports.Select(report => new ReportAndMerchantResource
                {
                    Id = report.Id,
                    Type = report.ReportType?.Name ?? string.Empty,
                    File = report.ReportFile,
                    Notes = report.ReportNotes?.Select(note => new ReportNote { ReportId = note.ReportId, Content = note.Content }).ToList() ?? new List<ReportNote>(),
                    Approved = (report.ApprovalStatus?.Id >= 5) ? 1 : 0,
                    Month = report.Month,
                    Year = report.Year,
                    MerchantName = report.OperatorReport?.Operator?.Company?.Name ?? string.Empty,
                    Status = report.ApprovalStatus?.Name ?? string.Empty
                });

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching reports from the database.", ex);
            }
        }

        public async Task<IEnumerable<ReportAndOperatorAnotherFormatResource>> GetReportsByOperatorReportAsync()
        {
            try
            {
                var operatorReports = await _reportOperatorRepository.GetAllReportsAsync();

                var distinctReportIds = operatorReports.Select(operatorReport => operatorReport.ReportId).Distinct().ToList();

                var reports = await _dbSet
                    .Where(report => distinctReportIds.Contains(report.Id))
                    .Include(report => report.ReportType)
                    .Include(report => report.ApprovalStatus)
                    .Include(report => report.OperatorReport)
                        .ThenInclude(operatorReport => operatorReport.Operator)
                            .ThenInclude(operatorEntity => operatorEntity.Company)
                    .Include(report => report.ReportNotes)
                    .ToListAsync();

                var joinedReports = reports.Join(
                    _reportingDBContext.OperatorReports,
                    report => report.Id,
                    operatorReport => operatorReport.ReportId,
                    (report, operatorReport) => new { Report = report, OperatorReport = operatorReport }
                );

                var result = joinedReports.Select(joinedReport => new ReportAndOperatorAnotherFormatResource
                {
                    Id = joinedReport.Report.Id,
                    Month = joinedReport.Report.Month,
                    Year = joinedReport.Report.Year,
                    Type = joinedReport.Report.ReportType?.Name ?? string.Empty,
                    File = joinedReport.Report.ReportFile,
                    DifferencesFile = joinedReport.OperatorReport.DifferencesFile,
                    MWFile = joinedReport.OperatorReport.MWFile,
                    IMIFile = joinedReport.OperatorReport.IMIFile,
                    RefundFile = joinedReport.OperatorReport.RefundFile,
                    Notes = joinedReport.Report.ReportNotes?.Select(note => new ReportNote
                    {
                        ReportId = note.ReportId,
                        Content = note.Content
                    }).ToList() ?? new List<ReportNote>(),
                    Approved = (joinedReport.Report.ApprovalStatus?.Id == 5) ? 1 : 0,
                    TelecomName = joinedReport.Report.OperatorReport?.Operator?.Company?.Name ?? string.Empty,
                });

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching reports from the database.", ex);
            }
        }
    }
}