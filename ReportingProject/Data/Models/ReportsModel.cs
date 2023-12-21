using System.ComponentModel.DataAnnotations;
using ReportingProject.Data.Entities;

namespace ReportingProject.Data.Models
{
	public class ReportsModel
	{
        [Required]
        public int TypeID { get; set; }

        public DateTime? LastModified { get; set; }

        public string Notes { get; set; } = string.Empty;

        public int Month { get; set; }

        public int Year { get; set; }

        [Required]
        public byte[]? ReportFile { get; set; }

        //foreign key
        public int ApprovalStatusId { get; set; }

        public ApprovalStatus ApprovalStatus { get; set; }
    }
}