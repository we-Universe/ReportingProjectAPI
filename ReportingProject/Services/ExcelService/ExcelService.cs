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
                string templateFilePath = "C:\\Users\\HP\\Downloads\\merged_file.xlsx";

                using (var workbook = new XLWorkbook(templateFilePath))
                {
                    //var pullTask = ReadAndWritePullSheetAsync(files.PullFile, workbook);
                    //var pushTask = ReadAndWritePushSheetAsync(files.PushFile, workbook);
                    //var dcbTask = ReadAndWriteDCBSheetAsync(files.DcbFile, workbook);

                    //await Task.WhenAll(pullTask, pushTask, dcbTask);

                    var pullDictionary = await _mergeExcelHelper.ReadPullFile(files.PullFile);
                    _mergeExcelHelper.WritePullFile(pullDictionary, workbook);

                    var (serviceDataDictionary, pushFreeServices) = await _mergeExcelHelper.ReadPushFile(files.PushFile);
                    _mergeExcelHelper.WritePushFile(serviceDataDictionary, pushFreeServices, workbook);

                    var dcbDictionary = await _mergeExcelHelper.ReadDCBFile(files.DcbFile);
                    _mergeExcelHelper.WriteDCBFile(dcbDictionary, workbook);

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

        //private async Task ReadAndWritePullSheetAsync(IFormFile pullFile, XLWorkbook workbook)
        //{
        //    var pullDictionary = await _mergeExcelHelper.ReadPullFile(pullFile);
        //    _mergeExcelHelper.WritePullFile(pullDictionary, workbook);
        //}

        //private async Task ReadAndWritePushSheetAsync(IFormFile pushFile, XLWorkbook workbook)
        //{
        //    var (serviceDataDictionary, pushFreeServices) = await _mergeExcelHelper.ReadPushFile(pushFile);
        //    _mergeExcelHelper.WritePushFile(serviceDataDictionary, pushFreeServices, workbook);
        //}

        //private async Task ReadAndWriteDCBSheetAsync(IFormFile dcbFile, XLWorkbook workbook)
        //{
        //    var dcbDictionary = await _mergeExcelHelper.ReadDCBFile(dcbFile);
        //    _mergeExcelHelper.WriteDCBFile(dcbDictionary, workbook);
        //}


    }
}
