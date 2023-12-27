using System.ComponentModel.DataAnnotations;

namespace ReportingProject.Data.Models
{
    public class FileModel
    {
        [Required]
        public IFormFile PullFile { get; set; }
        public IFormFile PushFile { get; set; }
        public IFormFile DcbFile { get; set; }


    }
}
