using Microsoft.EntityFrameworkCore;
using ReportingProject.Data.Contextes;
using ReportingProject.Data.Entities;

namespace ReportingProject.Repositories.InvoiceRepository
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly ReportingDBContext _reportingDBContext;
        
        public InvoiceRepository(ReportingDBContext reportingDBContex)
        {
            _reportingDBContext = reportingDBContex;
           
        }

        public async Task<bool> AddInvoiceReportAsync(Invoice invoice)
        {
             try
            {
                _reportingDBContext.Invoices.Add(invoice);
               
                // Save changes to generate the InvoiceId (assuming InvoiceId is an identity column)
                await _reportingDBContext.SaveChangesAsync();

                //if (invoice.InvoiceNotes != null && invoice.InvoiceNotes.Any())
                //{
                //    foreach (var note in invoice.InvoiceNotes)
                //    {
                //        //note.InvoiceId = invoice.ID;
                //        _reportingDBContext.InvoiceNotes.Add(note);
                //    }

                //    await _reportingDBContext.SaveChangesAsync();
                //}

                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex}");
                return false;
            }
            return true;
        }
    }
}
