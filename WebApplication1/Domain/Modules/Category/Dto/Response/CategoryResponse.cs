using Domain.Enum;

namespace Domain.Modules.Category.Dto.Response;

public class CategoryResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string PageKey { get; set; } = default!;
    public int? ParentCategoryId { get; set; }
    public string? ParentCategoryName { get; set; }
    public Status Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
