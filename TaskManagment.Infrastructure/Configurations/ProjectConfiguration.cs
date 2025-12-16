using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagment.Domain.Entities;

namespace TaskManagment.Infrastructure.Configurations;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
        builder.Property(x => x.Description).HasMaxLength(1000);
        builder.HasMany(x => x.Tasks).WithOne().OnDelete(DeleteBehavior.Cascade);
        
    }
}