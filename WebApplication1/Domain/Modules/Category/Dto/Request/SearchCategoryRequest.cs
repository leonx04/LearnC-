using System.ComponentModel.DataAnnotations;
using Application.Common;

namespace Domain.Modules.Category.Dto.Request;

public class SearchCategoryRequest : SearchQuery
{
    [Required(ErrorMessage = "PageKey là bắt buộc")] 
    public required string PageKey { get; set; }
    public int? ParentCategoryId { get; set; }
}
