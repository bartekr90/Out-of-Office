using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OutOfOffice.Domain;
using OutOfOffice.Domain.Model.Entities;
using OutOfOffice.Infrastructure.Configuration;

namespace OutOfOffice.Infrastructure;

public class Context : IdentityDbContext
{
    public virtual DbSet<AbsenceReason> AbsenceReasons { get; set; }
    public virtual DbSet<ApprovalRequest> ApprovalRequests { get; set; }
    public virtual DbSet<Employee> Employees { get; set; }
    public virtual DbSet<LeaveRequest> LeaveRequests { get; set; }
    public virtual DbSet<Position> Positions { get; set; }
    public virtual DbSet<Project> Projects { get; set; }
    public virtual DbSet<ProjectType> ProjectTypes { get; set; }
    public virtual DbSet<Status> Statuses { get; set; }
    public virtual DbSet<Subdivision> Subdivisions { get; set; }

    public Context(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new AuditableModelConfiguration());
        modelBuilder.ApplyConfiguration(new BaseEntityConfiguration());
        modelBuilder.ApplyConfiguration(new ApprovalRequestConfiguration());
        modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        modelBuilder.ApplyConfiguration(new LeaveRequestConfiguration());
        modelBuilder.ApplyConfiguration(new ProjectConfiguration());

        modelBuilder.Entity<ProjectType>(entity =>
        {
            entity.Property(e => e.Name).IsRequired().HasMaxLength(30);
            entity.HasQueryFilter(e => !e.Deleted);
        });

        modelBuilder.Entity<AbsenceReason>(entity =>
        {
            entity.Property(e => e.Name).IsRequired().HasMaxLength(30);
            entity.HasQueryFilter(e => !e.Deleted);
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.Property(e => e.Name).IsRequired().HasMaxLength(30);
            entity.HasQueryFilter(e => !e.Deleted);
        });

        modelBuilder.Entity<Subdivision>(entity =>
        {
            entity.Property(e => e.Name).IsRequired().HasMaxLength(30);
            entity.HasQueryFilter(e => !e.Deleted);
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.Property(e => e.Name).IsRequired().HasMaxLength(30);
            entity.HasQueryFilter(e => !e.Deleted);
        });

        List<IdentityRole> roles = Enum.GetValues(typeof(Role))
           .Cast<Role>()
           .Distinct()
           .Select(e => new IdentityRole
           {
               Id = e.ToString(),
               Name = e.ToString(),
               NormalizedName = e.ToString().ToUpper()
           })
           .ToList();

        if (roles.GroupBy(r => r.Id).Any(g => g.Count() > 1))
        {
            //TODO
            //Console.WriteLine($"Error seeding roles: {ex.Message}");
            throw new InvalidOperationException("Duplicate roles detected in the Role enum.");
        }

        try
        {
            modelBuilder.Entity<IdentityRole>().HasData(roles);
        }
        catch (Exception ex)
        {
            // Log the error (replace with your logging mechanism)
            throw;
        }
    }
}


