using Domain.Modules.Faq.Dto.Response;

namespace Domain.Modules.Faq.Dto.Response;

public class FaqGroupedResponse
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public List<FaqResponse> Faqs { get; set; } = new List<FaqResponse>();
}
