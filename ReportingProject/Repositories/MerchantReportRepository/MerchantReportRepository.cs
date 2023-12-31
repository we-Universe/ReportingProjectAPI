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
            //var x = await _reportingDBContext.Revenues
            //    .Include(rev => rev.Service)
            //    .ThenInclude(ser => ser.ServiceOperators)
            //    .ThenInclude(serOp => serOp.Operator)
            //    .ThenInclude(op => op.Company)
            //    .ThenInclude(comp => comp.Currency).ToListAsync();

            var e = await _reportingDBContext.Merchants.Where(mer => mer.Id == 1)
                .Include(merch => merch.Consultant)
                .Include(merch => merch.Contracts)
                .ThenInclude(contract => contract.Service)
                .ThenInclude(ser => ser.Revenues)
                .ThenInclude(ser => ser.Service)
                .ThenInclude(serOp=> serOp.ServiceOperators)
                .ThenInclude(serOp => serOp.Operator)
                .ThenInclude(op => op.Company)
                .ThenInclude(comp => comp.Currency).ToListAsync();

            //int clientRef = 0;
            //int clientShare = 0;

            //foreach(Merchant merchant in e)
            //{
            //    clientRef = merchant.Consultant.Client.ClientRef;
              

            //}

            return await _dbSet.ToListAsync();
        }
    }
}
