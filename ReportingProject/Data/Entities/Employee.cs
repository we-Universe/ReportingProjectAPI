namespace ReportingProject.Data.Entities
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty; 
        public string Position { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        public List<Merchant>? Merchants { get; set; }
    }
}