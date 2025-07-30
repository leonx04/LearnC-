using Application.Common;
using Domain.Enum;
using Domain.Modules.Faq.Dto.Request;
using Domain.Modules.Faq.Dto.Response;
using Domain.Modules.Faq.Repository;
using Domain.Modules.Faq.Services;

namespace Infrastructure.Modules.Faq.Services;

public class FaqService :  IFaqService
{
    public readonly IFaqRepository _repository;
    
    public FaqService(IFaqRepository repository)
    {
        _repository = repository;
    }


    public async Task<PagedResult<FaqResponse>> GetPagedAsync(SearchFaqRequest request)
    {
        var result = await _repository.GetPagedAsync(request);
        
        var responses = result.Items.Select(MapToResponse);
        
        return new PagedResult<FaqResponse>(
            responses, 
            result.TotalItemsCount, 
            request.PageSize, 
            request.PageNumber);
    }

    public async Task<FaqResponse?> GetByIdAsync(int id)
    {
        var faq = await _repository.GetByIdAsync(id);
        return faq != null ? MapToResponse(faq) : null;
    }

    public async Task<FaqResponse> CreateAsync(CreateFaqRequest request)
    {
        // Kiểm tra câu hỏi đã tồn tại
        if (await _repository.IsQuestionExistsAsync(request.Question))
            throw new InvalidOperationException("Câu hỏi đã tồn tại");

        // Kiểm tra danh mục có tồn tại không
        if (!await _repository.CheckCategoryExistsAsync(request.CategoryId))
            throw new InvalidOperationException("Danh mục không tồn tại");

        var faq = new Domain.Modules.Faq.Entity.Faq
        {
            Question = request.Question,
            Answer = request.Answer,
            Status = (Status)request.Status,
            CategoryId = request.CategoryId
        };

        var createdFaq = await _repository.CreateAsync(faq);
        return MapToResponse(createdFaq);
    }

    public async Task<FaqResponse?> UpdateAsync(int id, UpdateFaqRequest request)
    {
        var existingFaq = await _repository.GetByIdAsync(id);
        if (existingFaq == null)
            return null;
        // Kiểm tra câu hỏi đã tồn tại
        if (await _repository.IsQuestionExistsAsync(request.Question, id))
            throw new InvalidOperationException("Câu hỏi đã tồn tại");
        // Kiểm tra danh mục có tồn tại không
        if (!await _repository.CheckCategoryExistsAsync(request.CategoryId))
            throw new InvalidOperationException("Danh mục không tồn tại");
        
        existingFaq.Question = request.Question;
        existingFaq.Answer = request.Answer;
        existingFaq.Status = (Status)request.Status;
        existingFaq.CategoryId = request.CategoryId;
        
        var updatedFaq = await _repository.UpdateAsync(existingFaq);
        return MapToResponse(updatedFaq);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var faq = await _repository.GetByIdAsync(id);
        if (faq == null) 
            return false;
        return await _repository.DeleteAsync(id);
    }

    private static FaqResponse MapToResponse(Domain.Modules.Faq.Entity.Faq faq)
    {
        return new FaqResponse
        {
            Id = faq.Id,
            Question = faq.Question,
            Answer = faq.Answer,
            Status = faq.Status,
            CategoryId = faq.CategoryId,
            CreatedAt = faq.CreatedAt,
            UpdatedAt = faq.UpdatedAt
        };
    }
}
