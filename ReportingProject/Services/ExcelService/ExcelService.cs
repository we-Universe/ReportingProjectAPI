using OfficeOpenXml;
using ReportingProject.Data.Models;
using ReportingProject.Data.Resources;

namespace ReportingProject.Services.ExcelService
{
    public class ExcelService : IExcelService
    {
        static ExcelService()
        {
            // Set the license context
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }
        public MergedFileResource MergeExcelFiles(FileModel files)
        {
            try
            {
                using (var package = new ExcelPackage())
                {
                 
                    AddWorksheetFromExcelFile(package, files.PushFile, "push");
                    AddWorksheetFromExcelFile(package, files.PullFile, "pull");
                    AddWorksheetFromExcelFile(package, files.DcbFile, "DCB");

                    using (var stream = new MemoryStream())
                    {
                        package.SaveAs(stream);

                        var mergedFileBytes = stream.ToArray();

                        var mergedFileResource = new MergedFileResource
                        {
                            MergedFileBytes = mergedFileBytes
                        };

                        return mergedFileResource;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error merging files: {ex.Message}");
                throw;
            }
        }

        private void AddWorksheetFromExcelFile(ExcelPackage package, IFormFile file, string sheetName)
        {
            if (file != null && file.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    file.CopyTo(memoryStream);
                    using (var excelPackage = new ExcelPackage(memoryStream))
                    {
                        var worksheet = excelPackage.Workbook.Worksheets[0];
                        var newWorksheet = package.Workbook.Worksheets.Add(sheetName, worksheet);
                    }
                }
            }
        }
    }
}