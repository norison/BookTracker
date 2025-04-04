using BookTracker.Api.Data.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookTracker.Api.Data.EntityTypeConfigurations;

public class AuditEntityTypeConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : AuditEntity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.Property(x => x.CreatedDateTime).IsRequired();
        builder.Property(x => x.ModifiedDateTime).IsRequired();
        builder.Property(x => x.CreatedBy).IsRequired();
        builder.Property(x => x.ModifiedBy).IsRequired();
    }
}