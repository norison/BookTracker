using BookTracker.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookTracker.Persistence.EntityConfigurations;

public class BookAuthorEntityTypeConfiguration : IEntityTypeConfiguration<BookAuthor>
{
    public void Configure(EntityTypeBuilder<BookAuthor> builder)
    {
        builder.ToTable("BookAuthor");
        builder.HasKey(x => new { x.AuthorId, x.BookId });

        builder
            .HasOne(x => x.Author)
            .WithMany(x => x.BookAuthors)
            .HasForeignKey(x => x.AuthorId);

        builder
            .HasOne(x => x.Book)
            .WithMany(x => x.BookAuthors)
            .HasForeignKey(x => x.BookId);
    }
}
