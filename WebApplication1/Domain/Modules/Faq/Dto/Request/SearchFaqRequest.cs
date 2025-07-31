using Application.Common;

namespace Domain.Modules.Faq.Dto.Request;

public class SearchFaqRequest : SearchQuery
{
    public int? CategoryId { get; set; }
    
    public bool? GroupByCategory { get; set; } = false;
}
