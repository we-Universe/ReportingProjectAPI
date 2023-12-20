namespace ReportingProject.Data.Entities
{
    public class Consultant
    {
        public int Id { get; set; }
        public int? ClientId { get; set; }
        public Client? Client { get; set; }
        public List<Merchant>? Merchants { get; set; }
    }
}
