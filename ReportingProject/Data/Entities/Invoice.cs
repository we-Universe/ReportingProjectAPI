using Microsoft.EntityFrameworkCore;

namespace ReportingProject.Data.Entities
{
    [Index(nameof(Month), nameof(Year))]
    public class Invoice
    {
        public int ID { get; set; }
        public int TotalAmount { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public DateTime BillingDate { get; set; }
        public DateTime? PaymentDate { get; set; }
        public DateTime LastModified { get; set; }
        public byte[]? SwiftFile { get; set; }
        public byte[]? ReceiptFile { get; set; }
        public int InvoiceStatusID { get; set; }
        public InvoiceStatus? InvoiceStatus { get; set; }
        public List<InvoiceNote>? InvoiceNotes { get; set;}
        public MerchantInvoice? MerchantInvoice { get; set; }
        public UniverseInvoice? UniverseInvoice { get; set; }

    }
}
