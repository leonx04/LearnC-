using Application.Common;
using Domain.Modules.Faq.Dto.Request;
using Domain.Modules.Faq.Dto.Response;

namespace Domain.Modules.Faq.Services;

public interface IFaqService
{
    Task<object> GetPagedAsync(SearchFaqRequest request);
    
    Task<FaqResponse?> GetByIdAsync(int id);
    
    Task<FaqResponse> CreateAsync(CreateFaqRequest request);
    
    Task<FaqResponse?> UpdateAsync(int id, UpdateFaqRequest request);
    
    Task<bool> DeleteAsync(int id);
    
}
