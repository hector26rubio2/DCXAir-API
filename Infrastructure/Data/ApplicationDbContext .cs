using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
      
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Transport> Transports { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Flight>()
                .HasOne(f => f.Transport)
                .WithMany(t => t.Flights)
                .HasForeignKey(f => f.TransportId);
        }
    }
}
