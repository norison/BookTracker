using BookTracker.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookTracker.Persistence.EntityConfigurations;

public class UserBookTrackerEntityTypeConfiguration : IEntityTypeConfiguration<UserBookTracker>
{
    public void Configure(EntityTypeBuilder<UserBookTracker> builder)
    {
        builder.ToTable("UserBookTracker");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.PageCount).IsRequired();
        builder.Property(x => x.CreatedDateTime).IsRequired();

        builder
            .HasOne(x => x.UserBook)
            .WithMany(x => x.UserBookTrackers)
            .HasForeignKey(x => new { x.BookId, x.UserId })
            .OnDelete(DeleteBehavior.Cascade);
    }
}
