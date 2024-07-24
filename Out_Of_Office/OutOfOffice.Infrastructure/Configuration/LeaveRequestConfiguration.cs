using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OutOfOffice.Domain.Model.Entities;

namespace OutOfOffice.Infrastructure.Configuration;

public class LeaveRequestConfiguration : IEntityTypeConfiguration<LeaveRequest>
{
    public void Configure(EntityTypeBuilder<LeaveRequest> builder)
    {
        builder.Property(e => e.EmployeeId).IsRequired();
        builder.Property(e => e.AbsenceReasonId).IsRequired();
        builder.Property(e => e.StatusId).IsRequired();
        builder.Property(e => e.StartDate).IsRequired();
        builder.Property(e => e.EndDate).IsRequired();
        builder.HasOne(e => e.Employee).WithMany(e => e.LeaveRequests).HasForeignKey(e => e.EmployeeId);
        builder.HasOne(e => e.Status).WithMany().HasForeignKey(e => e.StatusId);
        builder.HasOne(e => e.AbsenceReason).WithMany().HasForeignKey(e => e.AbsenceReasonId);
        builder.HasQueryFilter(e => !e.Deleted);
    }
}
