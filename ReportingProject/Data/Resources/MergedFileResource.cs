using System.ComponentModel.DataAnnotations;

namespace ReportingProject.Data.Resources
{
    public class MergedFileResource
    {
        [Required]
        public required byte[] MergedFileBytes { get; set; }
    }
}
