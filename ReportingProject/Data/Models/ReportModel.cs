using System.ComponentModel.DataAnnotations;

namespace ReportingProject.Data.Models
{
	public class ReportModel
	{
        [Required]
        public int ReportTypeId { get; set; }

        public DateTime? LastModified { get; set; }

        public int ApprovalStatusID { get; set; }

        public int Month { get; set; }

        public int Year { get; set; }

        [Required]
        public required byte[] ReportFile { get; set; }
    }
}