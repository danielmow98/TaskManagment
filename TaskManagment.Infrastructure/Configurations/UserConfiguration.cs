using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagment.Domain.Entities;

namespace TaskManagment.Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Email).IsRequired().HasMaxLength(255);
        builder.HasIndex(x => x.Email).IsUnique();
        builder.Property(x => x.PasswordHash).IsRequired();
    }
}