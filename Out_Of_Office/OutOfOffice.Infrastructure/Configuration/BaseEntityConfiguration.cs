using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OutOfOffice.Domain.Model.Abstract;
using OutOfOffice.Domain.Model.Entities;

namespace OutOfOffice.Infrastructure.Configuration;

public class BaseEntityConfiguration : IEntityTypeConfiguration<BaseEntity>
{
    public void Configure(EntityTypeBuilder<BaseEntity> builder)
    {
        builder.Property(e => e.Id).IsRequired();
        builder.Property(e => e.Deleted).IsRequired();
        builder.Property(e => e.DeletedBy);
        builder.Property(e => e.DeletedAt);
        builder.HasDiscriminator<string>("EntityType")
            .HasValue<ApprovalRequest>(nameof(ApprovalRequest))
            .HasValue<Employee>(nameof(Employee))
            .HasValue<LeaveRequest>(nameof(LeaveRequest))
            .HasValue<Project>(nameof(Project))
            .HasValue<ProjectType>(nameof(ProjectType))
            .HasValue<AbsenceReason>(nameof(AbsenceReason))
            .HasValue<Status>(nameof(Status))
            .HasValue<Subdivision>(nameof(Subdivision))
            .HasValue<Position>(nameof(Position));
    }
}