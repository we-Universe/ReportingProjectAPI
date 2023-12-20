namespace ReportingProject.Data.Entities
{
    public class CompanyEmail
    {
        public int Id { get; set; }
        public int? CompanyId { get; set; }
        public string EmailAddress { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Postion { get; set; } = string.Empty;
        public Company? Company { get; set; }


    }
}
