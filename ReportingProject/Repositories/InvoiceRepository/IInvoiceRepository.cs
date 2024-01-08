using ReportingProject.Data.Entities;

namespace ReportingProject.Repositories.InvoiceRepository
{
    public interface IInvoiceRepository
    {
         Task<bool> AddInvoiceReportAsync(Invoice invoice);
    }
}
