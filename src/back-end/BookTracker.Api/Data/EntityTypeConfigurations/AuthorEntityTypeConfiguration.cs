using BookTracker.Api.Data.Entities;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookTracker.Api.Data.EntityTypeConfigurations;

public class AuthorEntityTypeConfiguration : AuditEntityTypeConfiguration<Author>
{
    public override void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);

        base.Configure(builder);
    }
}