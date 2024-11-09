using KashmiriTourister.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace KashmiriTourister.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Landmarks> Landmarkss { get; set; }

        public DbSet<Blogs> Blogs { get; set; }

        public DbSet<CertificateRequest> CertificateRequest { get; set; } 
    }
}
