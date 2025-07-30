using Domain.Enum;

namespace Domain.Modules.Faq.Dto.Request;

public class CreateFaqRequest
{
    public string Question { get; set; } = string.Empty;
    
    public string Answer { get; set; } = string.Empty;
    
    public int CategoryId { get; set; }
    
    public Status Status { get; set; } = Status.Active;
}
