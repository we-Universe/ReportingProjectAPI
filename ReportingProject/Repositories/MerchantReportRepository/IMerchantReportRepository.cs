using ReportingProject.Data.Entities;
using ReportingProject.Data.Resources;

namespace ReportingProject.Repositories.MerchantReportRepository
{
	public interface IMerchantReportRepository
	{
        Task<IEnumerable<MerchantReport>> GetAllMerchantsReports();
        Task<IEnumerable<MerchantReportExcelResource>> GetDetailsDataForGeneratedMerchantReport(int merchantId, int month, int year);
    }
}