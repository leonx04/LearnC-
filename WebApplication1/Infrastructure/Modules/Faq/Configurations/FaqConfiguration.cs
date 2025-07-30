using Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Modules.Faq.Configurations;

public class FaqConfiguration : IEntityTypeConfiguration<Domain.Modules.Faq.Entity.Faq>
{
    public void Configure(EntityTypeBuilder<Domain.Modules.Faq.Entity.Faq> builder)
    {
        builder.ToTable("faqs");

        builder.Property(x => x.Status)
            .HasConversion<int>()
            .HasDefaultValue(Status.Active);

        builder.HasIndex(x => x.Question).IsUnique();
        builder.HasIndex(x => x.Answer);
        builder.HasIndex(x => x.Status);
    }
}
