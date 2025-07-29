using System.ComponentModel.DataAnnotations;

namespace Domain.Modules.Category.Dto.Request;

public class SearchCategoryRequest
{
    public string? Name { get; set; }
    [Required(ErrorMessage = "PageKey là bắt buộc")] 
    public required string PageKey { get; set; }
    public int? ParentCategoryId { get; set; }
    public int? Status { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? SortBy { get; set; } = "CreatedAt";
    public string? SortOrder { get; set; } = "DESC";
}
