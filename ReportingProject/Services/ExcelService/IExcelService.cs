using ReportingProject.Data.Models;
using ReportingProject.Data.Resources;

namespace ReportingProject.Services.ExcelService
{
    public interface IExcelService
    {
        public MergedFileResource MergeExcelFiles(FileModel files);
    }
}
