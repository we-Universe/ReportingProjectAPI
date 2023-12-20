using System.ComponentModel.DataAnnotations;

namespace ReportingProject.Data.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int? CountryId { get; set; }
        public int? CurrencyId { get; set; }
        public string Address { get; set; } = string.Empty;
        public int Fax { get; set; }
        public int Phone { get; set;}
        public string Website { get; set; } = string.Empty;
        public DateTime? CreationDate { get; set; }
        public bool IsActive { get; set; }
        public Country? Country { get; set; }
        public Currency? Currency { get; set; }
        public List<CompanyEmail>? CompanyEmails { get; set; }
        public Operator? Operator { get; set; }
        public Client? Client { get; set; }

    }
}
