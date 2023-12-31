using ReportingProject.Data.Entities;

namespace ReportingProject.Repositories.MerchantReportRepository
{
    public interface IMerchantReportRepository
    {
        Task<IEnumerable<MerchantReport>> GetAllMerchantsReports();
    }
}
