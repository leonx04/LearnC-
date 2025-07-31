using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Modules.User.Configurations;

public class UserConfigurations : IEntityTypeConfiguration<Domain.Modules.User.Entity.User>
{
    public void Configure(EntityTypeBuilder<Domain.Modules.User.Entity.User> builder)
    {
        builder.ToTable("users");

        builder.Property(x => x.Role)
            .HasConversion<int>()
            .HasDefaultValue(Domain.Enum.Role.User);
        
        
        builder.HasIndex(x => x.UserName).IsUnique();
        builder.HasIndex(x => x.Email).IsUnique();
        builder.HasIndex(x =>  x.Password);
        builder.HasIndex(x => x.Role);
        builder.HasIndex(x => x.Status);
    }
}
