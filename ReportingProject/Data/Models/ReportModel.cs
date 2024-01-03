using System.ComponentModel.DataAnnotations;

namespace ReportingProject.Data.Models
{
	public class ReportModel
	{
        public int Id { get; set; }

        [Required]
        public int ReportTypeId { get; set; }

        public DateTime? LastModified { get; set; }

        public int ApprovalStatusID { get; set; }

        public int Month { get; set; }

        public int Year { get; set; }

        [Required]
        public required byte[] ReportFile { get; set; }

        public int OperatorId { get; set; }

        public byte[]? IMIFile { get; set; }

        public byte[]? DifferencesFile { get; set; }

        public byte[]? MWFile { get; set; }

        public byte[]? RefundFile { get; set; }

        public List<NoteModel> Notes { get; set; } = new List<NoteModel>();
    }
}