using BookTracker.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookTracker.Persistence.EntityConfigurations;

public class RoleEntityTypeConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Role");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(20).IsRequired();

        builder.HasData(
            new Role { Id = 1, Name = "Admin" },
            new Role { Id = 2, Name = "Moderator" },
            new Role { Id = 3, Name = "User" });
    }
}
