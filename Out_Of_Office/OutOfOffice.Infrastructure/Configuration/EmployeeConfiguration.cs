using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OutOfOffice.Domain.Model.Entities;

namespace OutOfOffice.Infrastructure.Configuration;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.Property(e => e.FullName).IsRequired().HasMaxLength(100);
        builder.Property(e => e.Status).IsRequired();
        builder.Property(e => e.SubdivisionId).IsRequired();
        builder.Property(e => e.PositionId).IsRequired();
        builder.Property(e => e.PeoplePartnerId).IsRequired();
        builder.Property(e => e.OutOfOfficeBalance).IsRequired();
        builder.HasOne(e => e.Subdivision).WithMany().HasForeignKey(e => e.SubdivisionId);
        builder.HasOne(e => e.Position).WithMany().HasForeignKey(e => e.PositionId);
        builder.HasOne(e => e.PeoplePartner).WithMany().HasForeignKey(e => e.PeoplePartnerId);
        builder.HasMany(e => e.LeaveRequests).WithOne(e => e.Employee).HasForeignKey(e => e.EmployeeId);
        builder.HasMany(e => e.ApprovalRequests).WithOne(e => e.Approver).HasForeignKey(e => e.ApproverId);
        builder.HasMany(e => e.Projects).WithOne(e => e.ProjectManager).HasForeignKey(e => e.ProjectManagerId);
        builder.HasMany(e => e.Subordinates).WithOne().HasForeignKey(e => e.PeoplePartnerId);
        builder.HasQueryFilter(e => !e.Deleted);
    }
}
