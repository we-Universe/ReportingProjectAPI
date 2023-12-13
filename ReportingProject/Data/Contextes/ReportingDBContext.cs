using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReportingProject.Data.Entities;

namespace ReportingProject.Data.Contextes
{
    public class ReportingDBContext : IdentityDbContext
    {
        public ReportingDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Countries> Countries { get; set; }
    }
}
