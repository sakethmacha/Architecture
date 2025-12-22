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

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Employee>(entity =>
        //    {
        //        entity.HasKey(e => e.Id);

        //        entity.Property(e => e.Name)
        //              .IsRequired()
        //              .HasMaxLength(100);

        //        entity.Property(e => e.Email)
        //              .IsRequired()
        //              .HasMaxLength(150);

        //        entity.Property(e => e.LeaveBalance)
        //              .IsRequired();
        //    });


        //    modelBuilder.Entity<LeaveRequest>(entity =>
        //    {
        //        entity.HasKey(l => l.Id);

        //        entity.OwnsOne(l => l.Period, p =>
        //        {
        //            p.Property(x => x.From).IsRequired();
        //            p.Property(x => x.To).IsRequired();
        //        });
        //    });
        //    modelBuilder.Entity<LeavePeriod>(entity =>
        //    {
        //        entity.HasKey(l => l.Id);
        //    });
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
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

        public DbSet<Employee> Employees { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
