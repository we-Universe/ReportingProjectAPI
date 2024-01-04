using ClosedXML.Excel;
using ReportingProject.Data.DTO;

namespace ReportingProject.Helpers.MergeExcelHelper
{
    public interface IMergeExcelHelper
    {
        public void AddWorksheetFromExcelFile(XLWorkbook targetWorkbook, IFormFile file, string sheetname);
        public void CopyWorksheetData(IXLWorksheet sourceWorksheet, IXLWorksheet newWorksheet);
        public  Task<Dictionary<string, ServiceData>> ReadPullFile(IFormFile file);
        public  Task<(Dictionary<string, ServiceData>, PushFreeServices)> ReadPushFile(IFormFile file);
        public IFormFile WritePushFile(Dictionary<string, ServiceData> pushData, PushFreeServices freeServicesData);
        public IFormFile WritePullFile(Dictionary<string, ServiceData> pullData);
        public IFormFile SaveWorkbook(XLWorkbook workbook);
        public void SetHeaderStyle(IXLWorksheet worksheet);
        public void SetSecondTableStyle(IXLWorksheet worksheet, int row);
        public IFormFile WriteDCBFile(Dictionary<string, ServiceData> dcbData);
        public  Task<Dictionary<string, ServiceData>> ReadDCBFile(IFormFile file); 

    }
}
