using Microsoft.EntityFrameworkCore;

namespace TaskManagment.Infrastructure.Configurations;

public class UserProjectConfiguration
{
    public static void Configure(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity("UserProject", builder =>
        {
            builder.Property<Guid>("UserId");
            builder.Property<Guid>("ProjectId");
            builder.HasKey("UserId", "ProjectId");
        });
    }
}