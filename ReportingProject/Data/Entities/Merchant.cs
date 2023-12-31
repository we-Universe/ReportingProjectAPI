﻿namespace ReportingProject.Data.Entities
{
    public class Merchant
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        public int? ConsultantId { get; set; }
        public Consultant? Consultant { get; set; }
        public List<MerchantReport>? MerchantReports { get; set;}
        public List<MerchantInvoice>? MerchantInvoices { get; set; }
        public List<Contract>? Contracts { get; set; }
    }
}