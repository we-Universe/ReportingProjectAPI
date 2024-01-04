using ReportingProject.Data.Resources;

namespace ReportingProject.Services.MerchantReportService
{
    public interface IMerchantReportService
    {
        Task<IEnumerable<MerchantReportResource>> GetAllMerchantsReportsAsync();
        Task GenerateMerchantsReportsAsync();
    }
}
