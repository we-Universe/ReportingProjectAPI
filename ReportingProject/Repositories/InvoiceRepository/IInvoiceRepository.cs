using ReportingProject.Data.Entities;

namespace ReportingProject.Repositories.InvoiceRepository
{
    public interface IInvoiceRepository
    {
        public Task<bool> AddInvoiceReportAsync(Invoice invoice);
    }
}
