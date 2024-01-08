using ClosedXML.Excel;
using ReportingProject.Data.DTO;

namespace ReportingProject.Helpers.MergeExcelHelper
{
    public interface IMergeExcelHelper
    {
         //void AddWorksheetFromExcelFile(XLWorkbook targetWorkbook, IFormFile file, string sheetname);
         //void CopyWorksheetData(IXLWorksheet sourceWorksheet, IXLWorksheet newWorksheet);
          Task<Dictionary<string, ServiceData>> ReadPullFile(IFormFile file);
          Task<(Dictionary<string, ServiceData>, PushFreeServices)> ReadPushFile(IFormFile file);
         //IFormFile WritePushFile(Dictionary<string, ServiceData> pushData, PushFreeServices freeServicesData);
         //IFormFile WritePullFile(Dictionary<string, ServiceData> pullData);
         //IFormFile SaveWorkbook(XLWorkbook workbook);
         //void SetHeaderStyle(IXLWorksheet worksheet);
         //void SetSecondTableStyle(IXLWorksheet worksheet, int row);
        // IFormFile WriteDCBFile(Dictionary<string, ServiceData> dcbData);
          Task<Dictionary<string, ServiceData>> ReadDCBFile(IFormFile file);
        void WriteDCBFile(Dictionary<string, ServiceData> dcbData, XLWorkbook workbook);
        void WritePushFile(Dictionary<string, ServiceData> pushData, PushFreeServices freeServicesData, XLWorkbook workbook);
        void WritePullFile(Dictionary<string, ServiceData> pullData, XLWorkbook workbook);

    }
}
