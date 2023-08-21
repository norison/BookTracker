using BookTracker.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookTracker.Persistence.EntityConfigurations;

public class BookEntityTypeConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("Book");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Title).HasMaxLength(30).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(1000).IsRequired();
        builder.Property(x => x.Format).HasMaxLength(20).IsRequired();
        builder.Property(x => x.CreatedDateTime).IsRequired();
        builder.Property(x => x.UpdatedDateTime).IsRequired(false);
        builder.Property(x => x.PublishedYear).IsRequired();
        builder.Property(x => x.PageCount).IsRequired();
        
        builder
            .HasOne(x => x.Publisher)
            .WithMany(x => x.Books)
            .HasForeignKey(x => x.PublisherId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(x => x.Genre)
            .WithMany(x => x.Books)
            .HasForeignKey(x => x.GenreId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
