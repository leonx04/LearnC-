namespace Application.Common;

public class SearchQuery
{
    public string? KeyWord { get; set; }
    
    public int? Status { get; set; }
    
    public int PageNumber { get; set; } = 1;
    
    public int PageSize { get; set; } = 10;    
    
    public string? SortBy { get; set; }
    
    public string? SortOrder { get; set; }
}
