﻿using Microsoft.EntityFrameworkCore;
using ReportingProject.Data.Contextes;
using ReportingProject.Data.Entities;

namespace ReportingProject.Repositories.OperatorReportRepository
{
    public class OperatorReportRepository : IOperatorReportRepository
    {
        private readonly ReportingDBContext _reportingDBContext;
        private readonly DbSet<OperatorReport> _dbSet;

        public OperatorReportRepository(ReportingDBContext reportingDBContex)
        {
            _reportingDBContext = reportingDBContex;
            _dbSet = _reportingDBContext.Set<OperatorReport>();
        }

        public async Task UploadReportAsync(OperatorReport entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
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

        public async Task<IEnumerable<OperatorReport>> GetAllReportsAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<OperatorReport> GetReportByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id) ?? throw new Exception("Operator Report not found");
        }

        public async Task UpdateReportAsync(OperatorReport entity)
        {
            try
            {
                var existingEntity = await _dbSet.FindAsync(entity.Id);

                if (existingEntity != null)
                {
                    _reportingDBContext.Entry(existingEntity).State = EntityState.Detached;
                }

                _dbSet.Attach(entity);
                _reportingDBContext.Entry(entity).State = EntityState.Modified;

                await _reportingDBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving changes to the database: {ex.Message}");
                throw;
            }
        }

        public async Task<OperatorReport> GetOperatorReportByReportIdAsync(int reportId)
        {
            return await _dbSet.FirstOrDefaultAsync(or => or.ReportId == reportId) ?? throw new Exception("Operator Report not found");
        }

        public async Task<int> GetOperatorIdFromReportIdAsync(int reportId)
        {
            var operatorReport = await _dbSet
                .FirstOrDefaultAsync(or => or.ReportId == reportId);

            return operatorReport?.Id ?? 0; 
        }
    }
}