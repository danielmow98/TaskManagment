using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagment.Domain.Entities;

namespace TaskManagment.Infrastructure.Configurations;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Content).IsRequired().HasMaxLength(2000);
        builder.Property(x => x.CreatedAt).IsRequired();
    }
}