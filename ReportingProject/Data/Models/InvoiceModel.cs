
namespace ReportingProject.Data.Models
{
    public class InvoiceModel
    { 
        public int TotalAmount { get; set; }
        public int InvoiceStatusID { get; set; }
        public int? OperatorId { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public DateTime BillingDate { get; set; }
        public DateTime? PaymentDate { get; set; }
        public required byte[] InvoiceFile { get; set; } 
        public byte[]? SwiftFile { get; set; }
        public byte[]? ReceiptFile { get; set; }
        public List<InvoiceNoteModel> InvoiceNotes { get; set; } = new List<InvoiceNoteModel>();

    }
}
