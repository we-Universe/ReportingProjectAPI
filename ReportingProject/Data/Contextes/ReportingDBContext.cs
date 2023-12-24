using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReportingProject.Data.Entities;

namespace ReportingProject.Data.Contextes
{
    public class ReportingDBContext : IdentityDbContext<ApplicationUser>
    {
        public ReportingDBContext(DbContextOptions options) : base(options)
        {


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>()
            .HasOne(u => u.Country)
            .WithMany(c => c.Users)
            .HasForeignKey(u => u.CountryID);

            modelBuilder.Entity<Notification>()
                .HasOne(n => n.Sender)
                .WithMany(u => u.SentNotifications)
                .HasForeignKey(n => n.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Notification>()
                .HasOne(n => n.Receiver)
                .WithMany(u => u.ReceivedNotifications)
                .HasForeignKey(n => n.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ServiceOperator>()
                .HasKey(so => new { so.ServiceId, so.OperatorId });

            modelBuilder.Entity<ServiceOperator>()
                .HasOne(so => so.Service)
                .WithMany(s => s.ServiceOperators)
                .HasForeignKey(so => so.ServiceId);

            modelBuilder.Entity<ServiceOperator>()
                .HasOne(so => so.Operator)
                .WithMany(o => o.ServiceOperators)
                .HasForeignKey(so => so.OperatorId);


            modelBuilder.Entity<Client>()
                .HasOne(c => c.Company)
                .WithOne(c => c.Client)
                .HasForeignKey<Client>(c => c.CompanyId)
                .OnDelete(DeleteBehavior.SetNull);

            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Country> Countries { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<ServiceStatus> ServiceStatuses { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<InvoiceStatus> InvoiceStatuses { get; set; }
        public DbSet<ReportType> ReportTypes { get; set; }
        public DbSet<NotificationType> NotificationTypes { get; set; }
        public DbSet<IndustryType> IndustryTypes { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<FinancialAccount> FinancialAccounts { get; set; }
        public DbSet<Operator> Operators { get; set; }
        public DbSet<CompanyEmail> CompanyEmails { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<UniverseInvoice> UniverseInvoices { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Consultant> Consultants { get; set; }
        public DbSet<Merchant> Merchants { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<ApprovalStatus> ApprovalStatuses { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<OperatorReport> OperatorReports { get; set; }
        public DbSet<MerchantReport> MerchantReports { get; set; }
        public DbSet<InvoiceNote> InvoiceNotes { get; set; }
        public DbSet<MerchantInvoice> MerchantInvoices { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceOperator> ServiceOperators { get; set; }
        public DbSet<Revenue> Revenues { get; set; }
        public DbSet<UserSession> UserSessions { get; set; }
        public DbSet<ReportNote> ReportNotes { get; set; }

    }
}
