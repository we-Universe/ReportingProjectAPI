using System.ComponentModel.DataAnnotations;

namespace ReportingProject.Data.Models
{
	public class ReportModel
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
        public required byte[] ReportFile { get; set; }
    }
}