﻿using AutoMapper;
using ReportingProject.Data.Entities;
using ReportingProject.Data.Resources;
using ReportingProject.Repositories.ReportTypeRepository;

namespace ReportingProject.Services.ReportTypeService
{
    public class ReportTypeService : IReportTypeService
    {
        private readonly IReportTypeRepository _reportTypeRepository;
        private readonly IMapper _mapper;

        public ReportTypeService(IReportTypeRepository reportTypeRepository, IMapper mapper)
        {
            _reportTypeRepository = reportTypeRepository;
            _mapper = mapper;
        }
        public Task AddReportTypeAsync(ReportType entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteReportTypeAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ReportTypeResource>> GetAllReportsTypesAsync()
        {
            var reportsTypesEntities = await _reportTypeRepository.GetAllReportsTypesAsync();
            return _mapper.Map<IEnumerable<ReportTypeResource>>(reportsTypesEntities);
        }

        public Task<ReportType> GetReportTypeByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateReportTypeAsync(ReportType entity)
        {
            throw new NotImplementedException();
        }
    }
}
