using Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Modules.Category.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Domain.Modules.Category.Entity.Category>
{
    public void Configure(EntityTypeBuilder<Domain.Modules.Category.Entity.Category> builder)
    {
        builder.ToTable("categories");
        
        builder.Property(x => x.Status)
            .HasConversion<int>()
            .HasDefaultValue(Status.Active);
        
        builder.HasOne(x => x.ParentCategory)
            .WithMany()
            .HasForeignKey(x => x.ParentCategoryId)
            .OnDelete(DeleteBehavior.Restrict); // Không cho phép xóa nếu có category con 
        
        builder.HasIndex(x => x.Name).IsUnique();
        builder.HasIndex(x => x.PageKey);
        builder.HasIndex(x => x.Status);
        builder.HasIndex(x => x.ParentCategoryId);
    }
}
