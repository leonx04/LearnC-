using System.ComponentModel.DataAnnotations;
using Domain.Enum;

namespace Domain.Modules.Category.Dto.Request;

public class CreateCategoryRequest
{
    [Required(ErrorMessage = "Tên danh mục là bắt buộc")]
    [StringLength(100, ErrorMessage = "Tên danh mục không được vượt quá 100 ký tự")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Page Key là bắt buộc")]
    [StringLength(100, ErrorMessage = "Page Key không được vượt quá 100 ký tự")]
    public string PageKey { get; set; } = string.Empty;

    public int? ParentCategoryId { get; set; }

    [Required(ErrorMessage = "Trạng thái là bắt buộc")]
    public Status Status { get; set; } = Status.Active;
}
