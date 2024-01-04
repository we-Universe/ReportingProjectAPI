using ReportingProject.Data.Entities;

namespace ReportingProject.Data.Resources
{
	public class ReportAndMerchantResource
    {
        public int Id { get; set; }
        public string Type { get; set; } = string.Empty;
        public byte[]? File { get; set; }
        public List<ReportNote> Notes { get; set; } = new List<ReportNote>();
        public int Approved { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public string MerchantName { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}

