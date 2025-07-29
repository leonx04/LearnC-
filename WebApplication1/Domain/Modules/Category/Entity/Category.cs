using System.ComponentModel.DataAnnotations;
using Application.Entities;
using Domain.Enum;

namespace Domain.Modules.Category.Entity;

public class Category : DatimeTrackerEntity
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required, MaxLength(100)]
    public string PageKey { get; set; } = string.Empty;

    public int? ParentCategoryId { get; set; }

    // Navigation property - danh mục cha
    public Category? ParentCategory { get; set; }

    public Status Status { get; set; } = Status.Active;
}
