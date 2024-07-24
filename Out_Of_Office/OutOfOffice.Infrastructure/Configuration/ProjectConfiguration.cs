using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OutOfOffice.Domain.Model.Entities;

namespace OutOfOffice.Infrastructure.Configuration;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.Property(e => e.ProjectTypeId).IsRequired();
        builder.Property(e => e.StartDate).IsRequired();
        builder.Property(e => e.ProjectManagerId).IsRequired();
        builder.HasOne(e => e.ProjectType).WithMany().HasForeignKey(e => e.ProjectTypeId);
        builder.HasOne(e => e.ProjectManager).WithMany().HasForeignKey(e => e.ProjectManagerId);
        builder.HasQueryFilter(e => !e.Deleted);
    }
}
