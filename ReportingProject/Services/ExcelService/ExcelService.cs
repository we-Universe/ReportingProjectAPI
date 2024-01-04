using ClosedXML.Excel;
using ReportingProject.Data.Models;
using ReportingProject.Data.Resources;
using ReportingProject.Helpers.MergeExcelHelper;


namespace ReportingProject.Services.ExcelService
{
    public class ExcelService : IExcelService
    {
        private readonly IMergeExcelHelper _mergeExcelHelper; 

        public ExcelService(  IMergeExcelHelper mergeExcelHelper)
        {
          
            _mergeExcelHelper = mergeExcelHelper;
        }

        public async Task<MergedFileResource> MergeExcelFilesAsync(FileModel files)
        {
            try
            {
                using (var workbook = new XLWorkbook())
                {
                    var (serviceDataDictionary, pushFreeServices) = await _mergeExcelHelper.ReadPushFile(files.PushFile);
                    var pushFile = _mergeExcelHelper.WritePushFile(serviceDataDictionary, pushFreeServices);

                    var pullDictionary = await _mergeExcelHelper.ReadPullFile(files.PullFile);
                    var pullFile = _mergeExcelHelper.WritePullFile(pullDictionary);

                    var dcbDictionary = await _mergeExcelHelper.ReadDCBFile(files.DcbFile);
                    var dcbFile = _mergeExcelHelper.WriteDCBFile(dcbDictionary);

                    _mergeExcelHelper.AddWorksheetFromExcelFile(workbook, pushFile, "push");
                    _mergeExcelHelper.AddWorksheetFromExcelFile(workbook, pullFile, "pull");
                    _mergeExcelHelper.AddWorksheetFromExcelFile(workbook, dcbFile, "DCB");
                   
                    using (var stream = new MemoryStream())
                    {
                        workbook.SaveAs(stream);

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

    }
}
