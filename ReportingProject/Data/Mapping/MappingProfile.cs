using AutoMapper;
using ReportingProject.Data.Entities;
using ReportingProject.Data.Models;
using ReportingProject.Data.Resources;

namespace ReportingProject.Data.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Report, ReportResource>().ReverseMap();
            CreateMap<Report, ReportModel>().ReverseMap();
            CreateMap<ReportNote, ReportNoteResource>().ReverseMap();
            CreateMap<ReportType, ReportTypeResource>().ReverseMap();
            CreateMap<Invoice, InvoiceModel>().ReverseMap();
            CreateMap<InvoiceNote, InvoiceNoteModel>().ReverseMap();
            CreateMap<OperatorReport, OperatorReportsModel>().ReverseMap();
            CreateMap<OperatorReport, OperatorReportsResource>().ReverseMap();
            CreateMap<Country, CountryResource>().ReverseMap();
            CreateMap<ApprovalStatus, ApprovalStatusesResource>().ReverseMap();
            CreateMap<MerchantReport, MerchantReportResource>().ReverseMap();
        }
    }
}