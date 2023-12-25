using ReportingProject.Data.Entities;
using ReportingProject.Data.Models;

namespace ReportingProject.Services.InvoiceService
{
    public interface IInvoiceService
    { 
       Task<bool> AddInvoiceReportAsync(InvoiceModel invoiceModel);
    }
}
