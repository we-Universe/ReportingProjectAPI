using ReportingProject.Data.Models;
using ReportingProject.Data.Resources;

namespace ReportingProject.Services.ExcelService
{
    public interface IExcelService
    {
         Task<MergedFileResource> MergeExcelFilesAsync(FileModel files);
    }
}
