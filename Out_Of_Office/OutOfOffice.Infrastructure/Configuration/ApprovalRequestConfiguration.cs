using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OutOfOffice.Domain.Model.Entities;

namespace OutOfOffice.Infrastructure.Configuration;

public class ApprovalRequestConfiguration : IEntityTypeConfiguration<ApprovalRequest>
{
    public void Configure(EntityTypeBuilder<ApprovalRequest> builder)
    {
        builder.Property(e => e.ApproverId).IsRequired();
        builder.Property(e => e.LeaveRequestId).IsRequired();
        builder.Property(e => e.StatusId).IsRequired();
        builder.HasOne(e => e.Approver).WithMany().HasForeignKey(e => e.ApproverId);
        builder.HasOne(e => e.LeaveRequest).WithMany().HasForeignKey(e => e.LeaveRequestId);
        builder.HasOne(e => e.Status).WithMany().HasForeignKey(e => e.StatusId);
        builder.HasQueryFilter(e => !e.Deleted);
    }
}
