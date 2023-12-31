﻿using System;
using Microsoft.EntityFrameworkCore;
using ReportingProject.Data.Contextes;
using ReportingProject.Data.Entities;
using System.Text.RegularExpressions;

namespace ReportingProject.Repositories.MerchantReportRepository
{
	public class MerchantReportRepository : IMerchantReportRepository
    {
        private readonly ReportingDBContext _reportingDBContext;
        private readonly DbSet<MerchantReport> _dbSet;
        public MerchantReportRepository(ReportingDBContext reportingDBContex)
        {
            _reportingDBContext = reportingDBContex;
            _dbSet = _reportingDBContext.Set<MerchantReport>();
        }

        public async Task<IEnumerable<MerchantReport>> GetAllMerchantsReports()
        {
            return await _dbSet.ToListAsync();
        }
    }
}