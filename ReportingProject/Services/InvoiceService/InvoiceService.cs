using AutoMapper;
using DocumentFormat.OpenXml.Bibliography;
using ReportingProject.Data.Entities;
using ReportingProject.Data.Models;
using ReportingProject.Data.Resources;
using ReportingProject.Repositories.InvoiceRepository;

namespace ReportingProject.Services.InvoiceService
{
    public class InvoiceService : IInvoiceService
    {

       
        private readonly IInvoiceRepository _invoiceRepository; 
        private readonly IMapper _mapper;

        public InvoiceService(IInvoiceRepository invoiceRepository, IMapper mapper)
        {
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
        }
  

        public async Task<bool> AddInvoiceReportAsync(InvoiceModel invoiceModel)

        {
   
            var invoiceEntity = _mapper.Map<Invoice>(invoiceModel);
            invoiceEntity.InvoiceNotes = _mapper.Map<List<InvoiceNote>>(invoiceModel.InvoiceNotes);
            invoiceEntity.LastModified = DateTime.Now;
            return  await _invoiceRepository.AddInvoiceReportAsync(invoiceEntity);   
        }
    }
}
