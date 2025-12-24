using Microsoft.EntityFrameworkCore;
using WebApp.Domain.Entities;
using WebApp.Domain.Aggregate;
using WebApp.Domain.ValueObjects;
namespace WebApp.Infrastructure.Persistance
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
            });
            modelBuilder.Entity<LeaveRequest>(entity =>
            {
                entity.HasKey(l => l.Id);

                entity.OwnsOne(l => l.Period, p =>
                {
                    p.Property(x => x.From)
                     .HasColumnName("FromDate")
                     .IsRequired();

                    p.Property(x => x.To)
                     .HasColumnName("ToDate")
                     .IsRequired();
                });
            });
        }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
