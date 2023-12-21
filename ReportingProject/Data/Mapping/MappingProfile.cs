using AutoMapper;
using ReportingProject.Data.Entities;
using ReportingProject.Data.Resources;

namespace ReportingProject.Data.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Report, ReportResource>().ReverseMap();
            CreateMap<ReportNote, ReportNoteResource>().ReverseMap();
            CreateMap<ReportType, ReportTypeResource>().ReverseMap();
        }
    }
}
