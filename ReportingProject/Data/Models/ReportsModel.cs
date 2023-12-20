using System.ComponentModel.DataAnnotations;

namespace ReportingProject.Data.Models
{
	public class ReportsModel
	{
        [Required]
        public int TypeID { get; set; }

        public DateTime? LastModified { get; set; }

        [Required]
        public int ApprovalStatusID { get; set; }

        public string Notes { get; set; } = string.Empty;

        public int Month { get; set; }

        public int Year { get; set; }

        [Required]
        public byte[]? ReportFile { get; set; }
    }
}