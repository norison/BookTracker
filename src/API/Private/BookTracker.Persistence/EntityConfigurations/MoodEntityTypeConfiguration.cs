using BookTracker.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookTracker.Persistence.EntityConfigurations;

public class MoodEntityTypeConfiguration : IEntityTypeConfiguration<Mood>
{
    public void Configure(EntityTypeBuilder<Mood> builder)
    {
        builder.ToTable("Mood");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(50).IsRequired();

        builder.HasData(
            new Mood { Id = 1, Name = "Sad" },
            new Mood { Id = 2, Name = "Neutral" },
            new Mood { Id = 3, Name = "Happy" });
    }
}
