using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OutOfOffice.Domain.Model.Abstract;

namespace OutOfOffice.Infrastructure.Configuration;

public class AuditableModelConfiguration : IEntityTypeConfiguration<AuditableModel>
{
    public void Configure(EntityTypeBuilder<AuditableModel> builder)
    {
        builder.Property(e => e.CreatorId).IsRequired();
        builder.Property(e => e.CreatedAt).IsRequired().HasDefaultValueSql("GETUTCDATE()");
        builder.Property(e => e.ModifierId);
        builder.Property(e => e.ModifiedAt);
    }

}
