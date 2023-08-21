using BookTracker.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookTracker.Persistence.EntityConfigurations;

public class GenreEntityTypeConfiguration : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder.ToTable("Genre");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(50).IsRequired();

        builder.HasData(
            new Genre { Id = 1, Name = "Fantasy" },
            new Genre { Id = 2, Name = "Science Fiction" },
            new Genre { Id = 3, Name = "Horror" },
            new Genre { Id = 4, Name = "Thriller" },
            new Genre { Id = 5, Name = "Mystery" },
            new Genre { Id = 6, Name = "Historical Fiction" },
            new Genre { Id = 7, Name = "Romance" },
            new Genre { Id = 8, Name = "Western" },
            new Genre { Id = 9, Name = "Contemporary" },
            new Genre { Id = 10, Name = "Memoir" },
            new Genre { Id = 11, Name = "Cooking" },
            new Genre { Id = 12, Name = "Art" },
            new Genre { Id = 13, Name = "Self-Help" },
            new Genre { Id = 14, Name = "Development" },
            new Genre { Id = 15, Name = "Motivational" },
            new Genre { Id = 16, Name = "Health" },
            new Genre { Id = 17, Name = "History" },
            new Genre { Id = 18, Name = "Travel" },
            new Genre { Id = 19, Name = "Guide" },
            new Genre { Id = 20, Name = "Families & Relationships" },
            new Genre { Id = 21, Name = "Humor" },
            new Genre { Id = 22, Name = "Children's" });
    }
}
