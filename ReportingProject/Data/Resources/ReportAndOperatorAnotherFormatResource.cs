namespace ReportingProject.Data.Resources
{
	public class ReportAndOperatorAnotherFormatResource
	{
        public int Id { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public string Type { get; set; } = string.Empty;
        public byte[]? File { get; set; }
        public byte[]? DifferencesFile { get; set; }
        public byte[]? MWFile { get; set; }
        public byte[]? IMIFile { get; set; }
        public byte[]? RefundFile { get; set; }
        public List<Note> Notes { get; set; } = new List<Note>();
        public int Approved { get; set; }
        public string TelecomName { get; set; } = string.Empty;
    }
}