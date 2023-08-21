using BookTracker.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookTracker.Persistence.EntityConfigurations;

public class UserBookStatusEntityTypeConfiguration : IEntityTypeConfiguration<UserBookStatus>
{
    public void Configure(EntityTypeBuilder<UserBookStatus> builder)
    {
        builder.ToTable("UserBookStatus");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(50).IsRequired();

        builder.HasData(
            new UserBookStatus { Id = 1, Name = "Not Started" },
            new UserBookStatus { Id = 2, Name = "Reading" },
            new UserBookStatus { Id = 3, Name = "Completed" },
            new UserBookStatus { Id = 4, Name = "OnHold" });
    }
}
