using Domain.Enum;
using Domain.Modules.Category.Dto.Response;

namespace Domain.Modules.Faq.Dto.Response;

public class FaqResponse
{
    public int Id { get; set; }
    public string Question { get; set; } = string.Empty;
    public string Answer { get; set; } = string.Empty;
    public int CategoryId { get; set; } 
    public Status Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
