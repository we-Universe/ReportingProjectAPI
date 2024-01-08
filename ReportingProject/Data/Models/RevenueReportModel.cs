using System.ComponentModel.DataAnnotations;

namespace ReportingProject.Data.Models
{
	public class RevenueReportModel
    {
        public int Month { get; set; }
        public int Year { get; set; }

        [Required]
        public IFormFile RevenueFile { get; set; }
    }
}