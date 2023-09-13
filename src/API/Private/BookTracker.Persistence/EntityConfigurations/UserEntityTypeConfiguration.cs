using BookTracker.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookTracker.Persistence.EntityConfigurations;

public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Login).HasMaxLength(50).IsRequired();
        builder.Property(x => x.Email).HasMaxLength(70).IsRequired();
        builder.Property(x => x.PasswordHash).HasMaxLength(100).IsRequired();
        builder.Property(x => x.FirstName).HasMaxLength(30).IsRequired();
        builder.Property(x => x.LastName).HasMaxLength(30).IsRequired();
        
        builder
            .HasOne(x => x.Role)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.RoleId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
